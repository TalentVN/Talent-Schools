import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SchoolsAdminRoutingModule } from './schools-admin-routing.module';
import { SchoolsAdminComponent } from './schools-admin.component';
import { EditSchoolComponent } from './edit-school/edit-school.component';


@NgModule({
  declarations: [
    SchoolsAdminComponent,
    EditSchoolComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SchoolsAdminRoutingModule
  ]
})
export class SchoolsAdminModule { }
