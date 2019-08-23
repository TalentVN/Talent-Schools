import { Component, OnInit } from '@angular/core';

import { FormGroup, FormBuilder, Validators, FormControl, ValidationErrors } from '@angular/forms';
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
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      jwtRole: ['User', Validators.required],
      address: ['']
    }, { validator: this.checkPasswords });

    this.getUser();
  }

  // convenience getter for easy access to form fields
  get f() { return this.editForm.controls; }

  private checkPasswords(group: FormGroup): void {
    let pass = group.get('password').value;
    let confirmPasswordCtrl = group.get('confirmPassword');

    if (confirmPasswordCtrl.errors && !confirmPasswordCtrl.errors.mustMatch) {
      // return if another validator has already found an error on the confirmPasswordCtrl
      return;
    }

    if (pass !== confirmPasswordCtrl.value) {
      confirmPasswordCtrl.setErrors({ mustMatch: true });
    } else {
      confirmPasswordCtrl.setErrors(null);
    }
  }

  private getUser(): void {
    this.route.paramMap.pipe(
      map(params => this.userId = params.get('id')),
      filter(id => !!id),
      switchMap(id => this.userService.getUser(id))
    ).subscribe(
      user => {
        this.editForm.patchValue(user);
        this.editForm.setControl('password', new FormControl(''));
        this.editForm.setControl('confirmPassword', new FormControl(''));
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
