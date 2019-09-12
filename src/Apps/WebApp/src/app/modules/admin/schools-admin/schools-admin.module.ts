import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';

import { SchoolsAdminRoutingModule } from './schools-admin-routing.module';
import { SchoolsAdminComponent } from './schools-admin.component';
import { EditSchoolComponent } from './edit-school/edit-school.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    SchoolsAdminComponent,
    EditSchoolComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgSelectModule,
    SchoolsAdminRoutingModule,
    SharedModule
  ]
})
export class SchoolsAdminModule { }
