import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MajorsAdminComponent } from './majors-admin.component';
import { EditMajorComponent } from './edit-major/edit-major.component';


const routes: Routes = [
  {
    path: '',
    component: MajorsAdminComponent
  },
  {
    path: 'create',
    component: EditMajorComponent,
    pathMatch: 'full'
  },
  {
    path: ':id',
    component: EditMajorComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MajorsAdminRoutingModule { }
