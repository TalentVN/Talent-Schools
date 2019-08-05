import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SchoolsAdminRoutingModule } from './schools-admin-routing.module';
import { SchoolsAdminComponent } from './schools-admin.component';


@NgModule({
  declarations: [
    SchoolsAdminComponent
  ],
  imports: [
    CommonModule,
    SchoolsAdminRoutingModule
  ]
})
export class SchoolsAdminModule { }
