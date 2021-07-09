import { Component, OnInit } from '@angular/core';
import { Player } from '../player';
import { PlayerserviceService } from '../playerservice.service';

@Component({
  selector: 'app-playerlist',
  templateUrl: './playerlist.component.html',
  styleUrls: ['./playerlist.component.css']
})
export class PlayerlistComponent implements OnInit {

  //create a array for the players
  playerArr?: Player[];
  chosenPlayer?: Player;
  constructor(private playerservice: PlayerserviceService,  /*add other services here.*/) { }

  ngOnInit(): void {
    //fetch the list of players from the service.
    this.playerservice.GetPlayerlist().subscribe(
      x => this.playerArr = x, // the first argument ot subscribe handles the successful result of the method call
      y => console.log(`there was an error ${y}`),//the second arg callback func handles an error response
      () => console.log('This is the complete block callback function')// the 3rd callback arg always runs (just like a finally lock)
    );
  };

  PlayerDetails(p: number): void {
    //sort the playerArr for this player
    this.chosenPlayer = this.playerArr?.find(x => x.personid == p);
    // this.chosenPlayer = { personid: 123, fname: '', lname: '', mycountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 42000 };
  }
  SortByAgeFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.myage > b.myage) ? 1 : -1);
  }

  SortByFnameFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.fname.toLowerCase() > b.fname.toLowerCase()) ? 1 : -1);
  }

  SortByCountryFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.mycountry.toLowerCase() > b.mycountry.toLowerCase()) ? 1 : -1);
  }

  SortByPersonIdFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.personid > b.personid) ? 1 : -1);
  }



}
