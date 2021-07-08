import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { PlayerLandingpageComponent } from './player-landingpage/player-landingpage.component';
import { FormsModule } from '@angular/forms';
//components go above

@NgModule({
  declarations: [
    AppComponent,
    PlayerLandingpageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
