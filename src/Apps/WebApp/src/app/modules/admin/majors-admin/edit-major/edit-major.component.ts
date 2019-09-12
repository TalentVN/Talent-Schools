import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { map, filter, switchMap } from 'rxjs/operators';

import { MajorService } from 'src/app/core/services/major.service';

@Component({
  selector: 'app-edit-major',
  templateUrl: './edit-major.component.html',
  styleUrls: ['./edit-major.component.scss']
})
export class EditMajorComponent implements OnInit {

  editForm: FormGroup;
  loading = false;
  submitted = false;

  majorId: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private majorService: MajorService
  ) { }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      code: ['', Validators.required],
      description: [''],
      isActive: [true]
    });

    this.getMajor();
  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  private getMajor(): void {
    this.route.paramMap.pipe(
      map(params => this.majorId = params.get('id')),
      filter(id => !!id),
      switchMap(id => this.majorService.getMajor(id))
    ).subscribe(
      major => this.editForm.patchValue(major),
      error => console.error(error)
    );
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.editForm.invalid) {
      return;
    }

    this.loading = true;
    if (this.majorId) {
      this.updateMajor();
    } else {
      this.createMajor();
    }
  }

  private updateMajor(): void {
    this.majorService.updateMajor(this.editForm.value).subscribe(
      () => this.router.navigate(['..'], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }

  private createMajor(): void {
    this.majorService.createMajor(this.editForm.value).subscribe(
      () => this.router.navigate(['..'], { relativeTo: this.route }),
      error => {
        console.error(error);
        this.loading = false;
      });
  }
}
