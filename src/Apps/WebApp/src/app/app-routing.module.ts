import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./modules/home/home.module').then(s => s.HomeModule)
  },
  {
    path: 'schools',
    loadChildren: () => import('./modules/schools/schools.module').then(s => s.SchoolsModule)
  },
  {
    path: 'ranks',
    loadChildren: () => import('./modules/ranks/ranks.module').then(s => s.RanksModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
