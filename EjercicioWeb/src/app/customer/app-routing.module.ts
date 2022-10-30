import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router'
import { CustomerListComponent } from './customer-list/customer-list.component';


const appRoutes: Routes = [
  {
    path: "",
    children: [
      {
        path: "", component: CustomerListComponent
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


