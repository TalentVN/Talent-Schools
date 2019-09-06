import { Component, OnInit } from '@angular/core';

import { ProgramModel } from 'src/app/shared/models/Program.model';
import { EducationProgramService } from 'src/app/core/services/education-program.service';
import { PagingModel } from 'src/app/shared/models/Paging.model';

@Component({
  selector: 'app-programs-admin',
  templateUrl: './programs-admin.component.html',
  styleUrls: ['./programs-admin.component.scss']
})
export class ProgramsAdminComponent implements OnInit {

  paging: PagingModel<ProgramModel>;

  constructor(private programService: EducationProgramService) { }

  ngOnInit() {
    this.getPagingPrograms(1);
  }

  private getPagingPrograms(currentPage: number): void {
    this.programService.getPagingPrograms(currentPage).subscribe(
      paging => this.paging = paging,
      error => console.error(error)
    )
  }

  deleteProgram(id: string): void {
    if (confirm("Are you sure to delete this program?")) {
      this.programService.deleteProgram(id).subscribe(
        () => this.getPagingPrograms(this.paging.currentPage),
        error => console.error(error)
      );
    }
  }

  changeActiveProgram(id: string): void {
    this.programService.changeActiveProgram(id).subscribe(
      () => {
        let currentProgram = this.paging.data.find(p => p.id == id);
        currentProgram.isActive = !currentProgram.isActive;
      },
      error => console.error(error)
    )
  }
}
