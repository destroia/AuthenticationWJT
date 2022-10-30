import { Injectable } from '@angular/core';
import { Roles } from '../Models/roles.enum';
import { HttpClient } from '@angular/common/http';
import {  BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment.prod';
import jwt_decode, { JwtPayload } from 'jwt-decode';
import { Router } from '@angular/router';
//import { decode } from 'querystring';
//import * as decode from 'jwt-decode'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authStatus = new BehaviorSubject<Authorizer>(JSON.parse(localStorage.getItem("auth")) || defaultAuthStatus);
  authProvider  :(email: string, pass: string) => Observable<Token>;
  constructor(private http: HttpClient,private route: Router) {
    this.authProvider = this.UserauthProvider;
  }

  UserauthProvider(email: string, pass: string): Observable<Token>
  {
  return this.http.post<Token>(environment.urlServices + "Token/Post", { email: email, password: pass });
  }
  async login(email: string, pass: string) {
    let res =  await this.UserauthProvider(email, pass).toPromise();
    console.log("res", res)
    let dd = this.LoginDecode(res.access_Token);
    console.log("Ddd",dd)
    return null;
  }
  
  LoginDecode(token: string): any {
    this.logout();
    localStorage.setItem("jwt", token);
    const res = jwt_decode<Authorizer>(token);
    localStorage.setItem("auth", JSON.stringify(res));
    this.authStatus.next(res);
    return res; 
  }
  getToken(): string {
    try {
      return localStorage.getItem("jwt").toString();
    } catch (e) {
      return null;
    }
   
  }
    logout() {
      this.authStatus.next(defaultAuthStatus);
      localStorage.clear();
      this.route.navigate(["/login"]);
    }
}


class Token {
  access_Token: string; 
}

export interface Authorizer {
  unique_name: string;
  role: Roles;
  primarysid: string;
}
const defaultAuthStatus: Authorizer = { role: Roles.None, primarysid : null, unique_name: null };
