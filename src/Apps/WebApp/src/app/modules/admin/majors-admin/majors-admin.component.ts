import { Component, OnInit } from '@angular/core';

import { MajorModel } from 'src/app/shared/models/Major.model';
import { MajorService } from 'src/app/core/services/major.service';

@Component({
  selector: 'app-majors-admin',
  templateUrl: './majors-admin.component.html',
  styleUrls: ['./majors-admin.component.scss']
})
export class MajorsAdminComponent implements OnInit {

  majors: MajorModel[];

  constructor(private majorService: MajorService) { }

  ngOnInit() {
    this.getMajors();
  }

  private getMajors(): void {
    this.majorService.getMajors().subscribe(
      majors => this.majors = majors,
      error => console.error(error)
    )
  }

  deleteMajor(id: string): void {
    if (confirm("Are you sure to delete this major?")) {
      this.majorService.deleteMajor(id).subscribe(
        () => this.majors = this.majors.filter(s => s.id !== id),
        error => console.error(error)
      );
    }
  }

  changeActive(id: string): void {
    this.majorService.changeActiveMajor(id).subscribe(
      () => {
        let currentMajor = this.majors.find(p => p.id == id);
        currentMajor.isActive = !currentMajor.isActive;
      },
      error => console.error(error)
    )
  }
}
