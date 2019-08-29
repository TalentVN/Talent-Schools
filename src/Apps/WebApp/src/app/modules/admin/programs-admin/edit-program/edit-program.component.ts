import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { EducationProgramService } from 'src/app/core/services/education-program.service';
import { map, filter, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-edit-program',
  templateUrl: './edit-program.component.html',
  styleUrls: ['./edit-program.component.scss']
})
export class EditProgramComponent implements OnInit {

  editForm: FormGroup;
  loading = false;
  submitted = false;

  programId: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private programService: EducationProgramService
  ) { }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      code: ['', Validators.required],
      description: [''],
      isActive: [true]
    });

    this.getProgram();
  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  private getProgram(): void {
    this.route.paramMap.pipe(
      map(params => this.programId = params.get('id')),
      filter(id => !!id),
      switchMap(id => this.programService.getProgram(id))
    ).subscribe(
      program => this.editForm.patchValue(program),
      error => console.error(error)
    );
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.editForm.invalid) {
      return;
    }

    this.loading = true;
    if (this.programId) {
      this.updateProgram();
    } else {
      this.createProgram();
    }
  }

  private updateProgram(): void {
    this.programService.updateProgram(this.editForm.value).subscribe(
      () => this.router.navigate(['../'], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }

  private createProgram(): void {
    this.programService.createProgram(this.editForm.value).subscribe(
      () => this.router.navigate(['../'], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }
}
