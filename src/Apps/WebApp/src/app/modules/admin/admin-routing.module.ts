import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: '/admin/users',
        pathMatch: 'full'
      },
      {
        path: 'users',
        loadChildren: () => import('./users-admin/users-admin.module').then(s => s.UsersAdminModule)
      },
      {
        path: 'schools',
        loadChildren: () => import('./schools-admin/schools-admin.module').then(s => s.SchoolsAdminModule)
      },
      {
        path: 'programs',
        loadChildren: () => import('./programs-admin/programs-admin.module').then(s => s.ProgramsAdminModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
