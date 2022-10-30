import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError as observableThrowError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthHttpInterceptorService implements HttpInterceptor{

  constructor(private auth: AuthService, private route: Router) { }
  //intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //  const jwt = this.auth.getToken();
  //  const authRequest = req.clone({ setHeaders: { Authorization: "bearer " + jwt } });
  //  console.log("asdasdjj",jwt)
  //  return next.handle(authRequest).pipe(
  //    catchError((err, caught) => {
  //      if (err.status === 401) {
  //        this.route.navigate(["login"]);
  //      }

  //      return observableThrowError(err);
  //    }
  //      )

  //  )
  //  }
}
