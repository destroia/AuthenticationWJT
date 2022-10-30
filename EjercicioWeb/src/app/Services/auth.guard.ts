import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanActivateChild, CanLoad, Route, UrlSegment, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../Services/auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad{
  constructor(private auth: AuthService, private route: Router) {

  }
  canLoad(route: Route, segments: UrlSegment[]): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    return this.CheckLogin()
  }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
      throw new Error('Method not implemented.');
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  protected CheckLogin() {

      let token: any = this.auth.getToken();
      if (token === null || token === "") {
        alert("Inicia sesion para contunuar");
        this.route.navigate(["login"])
        return false;
      }
      return true;   
  }
  
}

function heckLogin() {
    throw new Error('Function not implemented.');
}
