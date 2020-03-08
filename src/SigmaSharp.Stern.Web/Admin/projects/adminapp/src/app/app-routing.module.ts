import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NavComponent } from './home/nav/nav.component';
import { ChangePassComponent } from './home/nav/change-pass/change-pass.component';
import { HeaderComponent } from './home/header/header.component';

import { DashboardComponent } from './home/dashboard/dashboard.component';
import { ModuleSettingsComponent } from './home/module-settings/module-settings.component';
import { ModuleDetailsComponent } from './home/module-details/module-details.component';
import { UsersComponent } from './home/users/users.component';
import { AdminsComponent } from './home/admins/admins.component';
import { AppSettingsComponent } from './home/app-settings/app-settings.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
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
