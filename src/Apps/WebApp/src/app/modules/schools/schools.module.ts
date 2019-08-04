import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SchoolsRoutingModule } from './schools-routing.module';
import { SharedModule } from '../../shared/shared.module';

import { ProfileComponent } from './profile/profile.component';
import { SchoolsComponent } from './schools.component';
import { SearchComponent } from './search/search.component';
import { RanksComponent } from './ranks/ranks.component';

@NgModule({
  declarations: [
    ProfileComponent,
    SchoolsComponent,
    SearchComponent,
    RanksComponent],
  imports: [
    CommonModule,
    SchoolsRoutingModule,
    SharedModule
  ]
})
export class SchoolsModule { }
