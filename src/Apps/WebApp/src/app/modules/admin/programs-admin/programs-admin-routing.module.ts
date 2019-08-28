import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProgramsAdminComponent } from './programs-admin.component';
import { EditProgramComponent } from './edit-program/edit-program.component';


const routes: Routes = [
  {
    path: '',
    component: ProgramsAdminComponent
  },
  {
    path: 'create',
    component: EditProgramComponent,
    pathMatch: 'full'
  },
  {
    path: ':id',
    component: EditProgramComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProgramsAdminRoutingModule { }
