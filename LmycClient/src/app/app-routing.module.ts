import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoatComponent } from './boat/boat.component';
import { BoatDetailComponent } from './boat-detail/boat-detail.component';

const routes: Routes = [
  { path: '', redirectTo: '/boats', pathMatch: 'full' },
  { path: 'detail/:id', component: BoatDetailComponent },
  { path: 'boats',     component: BoatComponent }
];
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
