import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PlayerlistComponent } from './playerlist/playerlist.component';
import { PlayerLandingpageComponent } from './player-landingpage/player-landingpage.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '**', pathMatch: 'full' },
  { path: 'playerlist', component: PlayerlistComponent },
  { path: 'playerlandingpage', component: PlayerLandingpageComponent },
  { path: '**', component: HomeComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
