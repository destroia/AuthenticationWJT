

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router'
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './Services/auth.guard';


const appRoutes: Routes = [
  {
    path: "Home", loadChildren: "./home/home.module#HomeModule",
    canLoad: [AuthGuard]
  },
  {
    path: "Customer", loadChildren: "./customer/customer.module#CustomerModule"
  },
  {
    path: "login", component: LoginComponent,
    canLoad: [AuthGuard]
  },
  {
    path: "", redirectTo: "/login", pathMatch: "full"
  },
  {
    path: "**", component: NotFoundComponent
  }

];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes),
  ], exports: [RouterModule
  ]
})
export class AppRoutingModule { }
