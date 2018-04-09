import { Component, OnInit } from '@angular/core';
import { BorrowService } from '../services/borrow.service';
import { Borrow } from '../models/borrow';
import { Router } from '@angular/router';

@Component({
  selector: 'app-borrow',
  templateUrl: './borrow.component.html',
  styleUrls: ['./borrow.component.css']
})
export class BorrowComponent implements OnInit {

  selected: Borrow;
  borrows: Borrow[];

  constructor(
    private borrowService: BorrowService,
    private router: Router
  ) { }

  onSelect(borrow: Borrow): void {
    this.selected = borrow;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selected.BoatId]);
  }

  getBoats(): void {
  this.borrowService.getBorrows()
    .then(borrows => this.borrows = borrows);
    // .then(borrows => console.log(borrows));
  }

  ngOnInit() {
    this.getBoats();
  }
}
