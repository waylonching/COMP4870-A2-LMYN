import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoatComponent } from './boat/boat.component';
import { BorrowComponent } from './borrow/borrow.component';
import { BoatDetailComponent } from './boat-detail/boat-detail.component';
import { BorrowDetailComponent } from './borrow-detail/borrow-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/boats', pathMatch: 'full' },
  { path: 'detail2/:id', component: BoatDetailComponent },
  { path: 'boats',     component: BoatComponent },
  { path: 'borrows',     component: BorrowComponent },
  { path: 'detail',     component: BorrowDetailComponent },
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
