import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { MajorsAdminRoutingModule } from './majors-admin-routing.module';
import { MajorsAdminComponent } from './majors-admin.component';
import { EditMajorComponent } from './edit-major/edit-major.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    MajorsAdminComponent,
    EditMajorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MajorsAdminRoutingModule,
    SharedModule
  ]
})
export class MajorsAdminModule { }
