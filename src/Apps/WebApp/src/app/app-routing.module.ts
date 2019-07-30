import { NgModule } from '@angular/core';
import { Routes, RouterModule, ExtraOptions } from '@angular/router';
import { AuthGuard } from './core/_guards/auth.guard';
import { RoleGuard } from './core/_guards/role.guard';
import { LoginComponent } from './shared/components/login/login.component';
import { RegisterComponent } from './shared/components/register/register.component';

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
    loadChildren: () => import('./modules/ranks/ranks.module').then(s => s.RanksModule),
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
