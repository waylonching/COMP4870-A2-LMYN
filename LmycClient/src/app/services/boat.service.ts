import { Injectable } from '@angular/core';
import { Boat } from '../models/boat';
import { Headers, Http, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class BoatService {

  private BASE_URL = 'https://comp4870-a2-rrwc.azurewebsites.net/api/boats/';

  constructor(private http: Http) { }

  getBoats(): Promise<Boat[]> {
    let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem('access_token') });
    let options = new RequestOptions({ headers: headers });

    return this.http.get(this.BASE_URL, options)
     .toPromise()
     .then(response => response.json() as Boat[])
     .catch(this.handleError);
  }

  getBoatById(id: number): Promise<Boat> {
    let headers = new Headers({ 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.getItem('access_token') });
    let options = new RequestOptions({ headers: headers });

    return this.http.get(this.BASE_URL + id, options)
      .toPromise()
      .then(response => response.json() as Boat[])
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
