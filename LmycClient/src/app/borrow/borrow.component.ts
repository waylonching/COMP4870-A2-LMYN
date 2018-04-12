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
  borrow: Borrow = new Borrow();

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

  getBorrows(): void {
  this.borrowService.getBorrows()
    .then(borrows => this.borrows = borrows);
  }

  createReservation() {
    console.log(this.borrow);

    this.borrowService.postBorrow(this.borrow)
      .then(response => {
        this.getBorrows()
        alert("Reservation created");
      });
  }

  ngOnInit() {
    this.getBorrows();
  }
}
