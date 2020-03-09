import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './services/auth/auth.guard';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { NavComponent } from './components/home/nav/nav.component';
import { ChangePassComponent } from './components/home/nav/change-pass/change-pass.component';
import { HeaderComponent } from './components/home/header/header.component';

import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { ModuleSettingsComponent } from './components/home/module-settings/module-settings.component';
import { ModuleDetailsComponent } from './components/home/module-details/module-details.component';
import { UsersComponent } from './components/home/users/users.component';
import { AdminsComponent } from './components/home/admins/admins.component';
import { AppSettingsComponent } from './components/home/app-settings/app-settings.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: DashboardComponent },
      { path: 'modules', component: ModuleSettingsComponent },
      { path: 'modules/:name', component: ModuleDetailsComponent },
      { path: 'users', component: UsersComponent },
      { path: 'admins', component: AdminsComponent },
      { path: 'settings', component: AppSettingsComponent },
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const RouteComponents = [
  NavComponent,
  HeaderComponent,
  DashboardComponent,
  ModuleSettingsComponent,
  ModuleDetailsComponent,
  UsersComponent,
  AdminsComponent,
  AppSettingsComponent,
  ChangePassComponent,
  LoginComponent,
  HomeComponent,
  NotFoundComponent
]
