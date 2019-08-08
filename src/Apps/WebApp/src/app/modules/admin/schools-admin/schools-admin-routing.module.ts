import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolsAdminComponent } from './schools-admin.component';
import { EditSchoolComponent } from './edit-school/edit-school.component';


const routes: Routes = [
  {
    path: '',
    component: SchoolsAdminComponent
  },
  {
    path: ':id',
    component: EditSchoolComponent
  },
  {
    path: 'create',
    component: EditSchoolComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolsAdminRoutingModule { }
