import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { SchoolsComponent } from './schools.component';
import { SchoolsRoutingModule } from './schools-routing.module';
import { SearchComponent } from './search/search.component';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    ProfileComponent,
    SchoolsComponent,
    SearchComponent],
  imports: [
    CommonModule,
    SchoolsRoutingModule,
    SharedModule
  ]
})
export class SchoolsModule { }
