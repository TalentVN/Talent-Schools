import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UsersAdminComponent } from '../users-admin/users-admin.component';
import { EditUserComponent } from '../users-admin/edit-user/edit-user.component';


const routes: Routes = [
  {
    path: '',
    component: UsersAdminComponent
  },
  {
    path: 'create',
    component: EditUserComponent,
    pathMatch: 'full'
  },
  {
    path: ':id',
    component: EditUserComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersAdminRoutingModule { }
