import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAdminComponent } from './user-admin.component';
import { EditUserComponent } from './edit-user/edit-user.component';



@NgModule({
  declarations: [UserAdminComponent, EditUserComponent],
  imports: [
    CommonModule
  ]
})
export class UserAdminModule { }
