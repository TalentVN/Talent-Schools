import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { UsersAdminRoutingModule } from './users-admin-routing.module';
import { UsersAdminComponent } from './users-admin.component';
import { EditUserComponent } from './edit-user/edit-user.component';


@NgModule({
  declarations: [
    UsersAdminComponent,
    EditUserComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    UsersAdminRoutingModule
  ]
})
export class UsersAdminModule { }
