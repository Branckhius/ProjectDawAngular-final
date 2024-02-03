import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AfisareCreareDateComponent } from './afisare-creare-date/afisare-creare-date.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './reactive-forms/register/register.component';
import { LoginComponent } from './reactive-forms/login/login.component';
import { AuthenticationService } from './core/services/authentication.service';
import { CommonModule } from "@angular/common";
import { JwtModule } from "@auth0/angular-jwt";
import { DemoPipe } from './core/pipes/demo.pipe';
import { AuthGuard } from "./core/guards/auth.guard";

@NgModule({
  declarations: [
    AppComponent,
    DemoPipe,
    NavMenuComponent,
    HomeComponent,
    NavMenuComponent,
    AfisareCreareDateComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent },
      { path: 'afisare-creare-date', component: AfisareCreareDateComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [AuthenticationService,
    AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
