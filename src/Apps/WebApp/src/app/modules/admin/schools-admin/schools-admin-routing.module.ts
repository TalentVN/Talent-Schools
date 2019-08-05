import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolsAdminComponent } from './schools-admin.component';


const routes: Routes = [
  {
    path: '',
    component: SchoolsAdminComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolsAdminRoutingModule { }
