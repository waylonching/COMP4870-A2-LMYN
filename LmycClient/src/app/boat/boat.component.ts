import { Component, OnInit } from '@angular/core';
import { BoatService } from '../services/boat.service';
import { Boat } from '../models/boat';
import { Router } from '@angular/router';

@Component({
  selector: 'app-boat',
  templateUrl: './boat.component.html',
  styleUrls: ['./boat.component.css']
})
export class BoatComponent implements OnInit {

  selected: Boat;
  boats: Boat[];

  constructor(
    private boatService: BoatService,
    private router: Router
  ) { }

  onSelect(boat: Boat): void {
    this.selected = boat;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selected.BoatId]);
  }

  getBoats(): void {
  this.boatService.getBoats()
    .then(boats => this.boats = boats)
    .then(boats => console.log(boats));
  }

  ngOnInit() {
    this.getBoats();
  }
}
