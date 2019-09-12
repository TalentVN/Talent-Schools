import { Component, OnInit } from '@angular/core';

import { SchoolModel } from 'src/app/shared/models/School.model';
import { SchoolService } from 'src/app/core/services/school.service';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Component({
  selector: 'app-schools-admin',
  templateUrl: './schools-admin.component.html',
  styleUrls: ['./schools-admin.component.scss']
})
export class SchoolsAdminComponent implements OnInit {

  paging: PagingModel<SchoolModel>;

  constructor(private schoolService: SchoolService) { }

  ngOnInit() {
    this.getPagingSchools(1);
  }

  private getPagingSchools(currentPage: number): void {
    this.schoolService.getPagingSchools(currentPage).subscribe(
      paging => this.paging = paging,
      error => console.error(error)
    );
  }

  deleteSchool(id: string): void {
    if (confirm("Are you sure to delete this school?")) {
      this.schoolService.deleteSchool(id).subscribe(
        () => this.getPagingSchools(this.paging.currentPage),
        error => console.error(error)
      );
    }
  }
}
