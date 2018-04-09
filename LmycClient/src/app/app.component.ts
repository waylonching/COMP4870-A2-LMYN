import { Component } from '@angular/core';
import { BoatService } from './services/boat.service';
import { BorrowService } from './services/borrow.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [BoatService, BorrowService],
})
export class AppComponent {
  title = 'LmycClient';
}
