import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MajorsAdminRoutingModule } from './majors-admin-routing.module';
import { MajorsAdminComponent } from './majors-admin.component';
import { EditMajorComponent } from './edit-major/edit-major.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    MajorsAdminComponent,
    EditMajorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MajorsAdminRoutingModule
  ]
})
export class MajorsAdminModule { }
