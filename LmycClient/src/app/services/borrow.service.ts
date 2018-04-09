import { Injectable } from '@angular/core';
import { Borrow } from '../models/borrow';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class BorrowService {

  private BASE_URL = 'https://localhost:44355/api/borrows';

  constructor(private http: Http) { }

  getBorrows(): Promise<Borrow[]> {
    return this.http.get(this.BASE_URL)
     .toPromise()
     .then(response => response.json() as Borrow[])
     .catch(this.handleError);
  }

  getBorrowById(id: number): Promise<Borrow> {
    return this.getBorrows()
      .then(result => result.find(borrow => borrow.BorrowId === id));
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
