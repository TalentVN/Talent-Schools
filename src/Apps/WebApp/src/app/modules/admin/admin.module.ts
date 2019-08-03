import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SchoolsAdminComponent } from './schools-admin/schools-admin.component';
import { MenuAdminComponent } from './menu-admin/menu-admin.component';


@NgModule({
  declarations: [
    AdminComponent,
    SchoolsAdminComponent,
    MenuAdminComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
