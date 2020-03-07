import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_BASE_HREF } from '@angular/common';
import { NavComponent } from './nav/nav.component';
import { HeaderComponent } from './header/header.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ModuleSettingsComponent } from './module-settings/module-settings.component';
import { ModuleDetailsComponent } from './module-details/module-details.component';
import { UsersComponent } from './users/users.component';
import { AdminsComponent } from './admins/admins.component';
import { AppSettingsComponent } from './app-settings/app-settings.component';
import { ChangePassComponent } from './nav/change-pass/change-pass.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HeaderComponent,
    DashboardComponent,
    ModuleSettingsComponent,
    ModuleDetailsComponent,
    UsersComponent,
    AdminsComponent,
    AppSettingsComponent,
    ChangePassComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [{ provide: APP_BASE_HREF, useValue: '/admin' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
