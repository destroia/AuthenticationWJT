import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private auth: AuthService, private route: Router) { }
  isLogueado: boolean = false;

  title = 'EjercicioWeb';
  ngOnInit(): void {
    this.auth.authStatus.subscribe(
      autho => {
        const jwt = localStorage.getItem("jwt") || "";
        setTimeout(() => {
          if (!(jwt == "" || jwt == null)) {
            this.isLogueado = true;
            this.route.navigate(["/Home"])
          }
          else {
            this.isLogueado = false;
          }});
      }
    )
  }
}
