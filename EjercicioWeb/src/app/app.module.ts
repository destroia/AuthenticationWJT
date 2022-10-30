import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CustomerModule } from './customer/customer.module';
import { HomeModule } from './home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard } from './Services/auth.guard';
import { AuthHttpInterceptorService } from './Services/auth-http-interceptor.service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
     
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptorService,
      multi : true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
