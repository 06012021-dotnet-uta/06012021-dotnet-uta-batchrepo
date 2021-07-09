import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PlayerLandingpageComponent } from './player-landingpage/player-landingpage.component';
import { FormsModule } from '@angular/forms';
import { ChildComponent } from './child/child.component';
import { AppRoutingModule } from './app-routing.module';
import { PlayerlistComponent } from './playerlist/playerlist.component';
import { HomeComponent } from './home/home.component';
import { PlayerdetailsComponent } from './playerdetails/playerdetails.component';
//components go above

@NgModule({
  declarations: [
    AppComponent,
    PlayerLandingpageComponent,
    ChildComponent,
    PlayerlistComponent,
    HomeComponent,
    PlayerdetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
