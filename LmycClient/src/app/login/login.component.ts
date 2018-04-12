import { Component } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginService]
})
export class LoginComponent {
  username: string;
  password: string;

  constructor(
    private loginService: LoginService,
    private router: Router
  ) { }

  login() {
    this.loginService.authenticate(this.username, this.password)
      .then(authenticated => {
        if (authenticated) {
          this.router.navigate(['/borrows']);
        } else {
          alert("Login failed");
        }
      });
  }
}
