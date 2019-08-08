import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { SchoolsComponent } from './schools.component';
import { SearchComponent } from './search/search.component';
import { RanksComponent } from './ranks/ranks.component';

const routes: Routes = [
  {
    path: '',
    component: SchoolsComponent,
    children: [
      {
        path: 'search',
        component: SearchComponent
      },
      {
        path: 'ranks',
        component: RanksComponent
      },
      {
        path: ':id',
        component: ProfileComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolsRoutingModule { }
