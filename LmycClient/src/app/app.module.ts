import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';


import { AppComponent } from './app.component';
import { BoatComponent } from './boat/boat.component';
import { BoatDetailComponent } from './boat-detail/boat-detail.component';
import { BorrowComponent } from './borrow/borrow.component';
import { BorrowDetailComponent } from './borrow-detail/borrow-detail.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    BoatComponent,
    BoatDetailComponent,
    BorrowComponent,
    BorrowDetailComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [LoginComponent, BorrowComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
