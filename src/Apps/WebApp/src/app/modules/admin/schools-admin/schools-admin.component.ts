import { Component, OnInit } from '@angular/core';
import { SchoolModel } from 'src/app/shared/models/School.model';
import { SchoolService } from 'src/app/core/services/school.service';

@Component({
  selector: 'app-schools-admin',
  templateUrl: './schools-admin.component.html',
  styleUrls: ['./schools-admin.component.scss']
})
export class SchoolsAdminComponent implements OnInit {

  schools: SchoolModel[];

  constructor(private schoolService: SchoolService) { }

  ngOnInit() {
    this.getSchools();
  }

  getSchools(): void {
    this.schoolService.getSchools().subscribe(
      schools => this.schools = schools,
      error => console.log(error)
    );
  }

  deleteSchool(id: string): void {
    if (confirm("Are you sure to delete this school?")) {
      this.schoolService.deleteSchool(id).subscribe(
        () => this.schools = this.schools.filter(s => s.id !== id),
        error => console.log(error)
      );
    }
  }
}
