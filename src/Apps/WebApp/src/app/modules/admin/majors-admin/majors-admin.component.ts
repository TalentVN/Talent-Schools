import { Component, OnInit } from '@angular/core';

import { MajorModel } from 'src/app/shared/models/Major.model';
import { MajorService } from 'src/app/core/services/major.service';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Component({
  selector: 'app-majors-admin',
  templateUrl: './majors-admin.component.html',
  styleUrls: ['./majors-admin.component.scss']
})
export class MajorsAdminComponent implements OnInit {

  paging: PagingModel<MajorModel>;

  constructor(private majorService: MajorService) { }

  ngOnInit() {
    this.getPagingMajors(1);
  }

  private getPagingMajors(currentPage: number): void {
    if (currentPage < 1) {
      currentPage = 1;
    }

    this.majorService.getPagingMajors(currentPage).subscribe(
      paging => this.paging = paging,
      error => console.error(error)
    )
  }

  deleteMajor(id: string): void {
    if (confirm("Are you sure to delete this major?")) {
      this.majorService.deleteMajor(id).subscribe(
        () => this.getPagingMajors(this.paging.currentPage),
        error => console.error(error)
      );
    }
  }

  changeActiveMajor(id: string): void {
    this.majorService.changeActiveMajor(id).subscribe(
      () => {
        let currentMajor = this.paging.data.find(p => p.id == id);
        currentMajor.isActive = !currentMajor.isActive;
      },
      error => console.error(error)
    )
  }
}
