import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MajorsAdminRoutingModule } from './majors-admin-routing.module';
import { MajorsAdminComponent } from './majors-admin.component';
import { EditMajorComponent } from './edit-major/edit-major.component';


@NgModule({
  declarations: [MajorsAdminComponent, EditMajorComponent],
  imports: [
    CommonModule,
    MajorsAdminRoutingModule
  ]
})
export class MajorsAdminModule { }
