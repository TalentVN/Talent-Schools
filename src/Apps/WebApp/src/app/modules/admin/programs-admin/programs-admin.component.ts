import { Component, OnInit } from '@angular/core';

import { ProgramModel } from 'src/app/shared/models/Program.model';
import { EducationProgramService } from 'src/app/core/services/education-program.service';

@Component({
  selector: 'app-programs-admin',
  templateUrl: './programs-admin.component.html',
  styleUrls: ['./programs-admin.component.scss']
})
export class ProgramsAdminComponent implements OnInit {

  programs: ProgramModel[];

  constructor(private programService: EducationProgramService) { }

  ngOnInit() {
    this.getPrograms();
  }

  private getPrograms(): void {
    this.programService.getPrograms().subscribe(
      programs => this.programs = programs,
      error => console.error(error)
    )
  }

  deleteProgram(id: string): void {
    if (confirm("Are you sure to delete this program?")) {
      this.programService.deleteProgram(id).subscribe(
        () => this.programs = this.programs.filter(s => s.id !== id),
        error => console.error(error)
      );
    }
  }

  changeActive(id: string): void {
    this.programService.changeActiveProgram(id).subscribe(
      () => {
        let currentProgram = this.programs.find(p => p.id == id);
        currentProgram.isActive = !currentProgram.isActive;
      },
      error => console.error(error)
    )
  }
}
