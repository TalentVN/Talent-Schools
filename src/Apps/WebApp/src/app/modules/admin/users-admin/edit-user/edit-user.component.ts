import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { map, filter, switchMap } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';

import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

  editForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  userId: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.editForm = this.formBuilder.group({
      id: [''],
      email: ['', Validators.required],
      password: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      jwtRole: ['', Validators.required],
      address: ['']
    });

    this.getUser();
  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  private getUser(): void {
    this.route.paramMap.pipe(
      map(params => this.userId = params.get('id')),
      filter(id => !!id),
      switchMap(id => this.userService.getUser(id))
    ).subscribe(
      user => {
        this.editForm.patchValue(user);
        this.editForm.setControl('password', new FormControl(''));
      },
      error => console.error(error)
    );
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.editForm.invalid) {
      return;
    }

    this.loading = true;
    if (this.userId) {
      this.updateUser();
    } else {
      this.createUser();
    }
  }

  private updateUser(): void {
    this.userService.updateUser(this.editForm.value).subscribe(
      result => {
        if (result.success) {
          this.router.navigate(['admin']);
        } else {
          this.error = result.errors[0].description;
          this.loading = false;
        }
      },
      error => {
        console.error(error);
        this.loading = false;
      });
  }

  private createUser(): void {
    this.userService.createUser(this.editForm.value).subscribe(
      result => {
        if (result.success) {
          this.router.navigate(['admin']);
        } else {
          this.error = result.errors[0].description;
          this.loading = false;
        }
      },
      error => {
        console.error(error);
        this.loading = false;
      });
  }
}
