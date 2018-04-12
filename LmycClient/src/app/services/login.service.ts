import { Injectable } from '@angular/core';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class LoginService {

  private BASE_URL = 'https://comp4870-a2-rrwc.azurewebsites.net/connect/token/';

  constructor(private http: Http) { }

  authenticate(username: string, password: string): Promise<any> {
    let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
    let body = "username=" + username + "&password=" + password + "&grant_type=password";
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.BASE_URL, body, options)
      .toPromise()
      .then(response => {
        if (response.json().access_token) {
          localStorage.setItem("access_token", response.json().access_token);
          return true;
        } else {
          alert("Authentication failed");
          return false;
        }
      })
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
