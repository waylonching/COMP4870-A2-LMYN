import { Injectable } from '@angular/core';
import { Borrow } from '../models/borrow';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class BorrowService {

  private BASE_URL = 'https://comp4870-a2-rrwc.azurewebsites.net/api/borrows/';

  constructor(private http: Http) { }

  getBorrows(): Promise<Borrow[]> {
    let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem('access_token') });
    let options = new RequestOptions({ headers: headers });

    return this.http.get(this.BASE_URL, options)
     .toPromise()
     .then(response => response.json() as Borrow[])
     .catch(this.handleError);
  }

  getBorrowById(id: number): Promise<Borrow> {
    let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem('access_token') });
    let options = new RequestOptions({ headers: headers });

    return this.http.get(this.BASE_URL + id, options)
      .toPromise()
      .then(response => response.json() as Borrow[])
      .catch(this.handleError);
  }

  postBorrow(borrow: Borrow): Promise<any> {
    let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem('access_token') });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.BASE_URL, borrow, options)
      .toPromise()
      .then(response => response.json())
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
