import { Injectable } from '@angular/core';
import { Boat } from '../models/boat';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

@Injectable()
export class BoatService {

  private BASE_URL = 'https://localhost:44355/api/boats';

  constructor(private http: Http) { }

  getBoats(): Promise<Boat[]> {
    return this.http.get(this.BASE_URL)
     .toPromise()
     .then(response => response.json() as Boat[])
     .catch(this.handleError);
  }

  // getBoatById(id: number): Promise<Boat> {
  //   return this.getBoats()
  //     .then(result => result.find(boat => boat.BoatId === id));
  // }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
