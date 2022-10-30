import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router'
import { HomeComponent } from './home/home.component';


const appRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "", component: HomeComponent
      }
    ]
    
  } 
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(appRoutes)
  ], exports: [RouterModule]
})
export class AppRoutingModule { }
