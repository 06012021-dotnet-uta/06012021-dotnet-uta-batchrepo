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
  showAddplayer: boolean = false;
  constructor(private playerservice: PlayerserviceService,  /*add other services here.*/) { }

  ngOnInit(): void {
    //fetch the list of players from the service.
    // IF YOU DO NOT SUBSCRIBE TO THE OBSERVABLE, NO SOUP FOR YOU!
    this.playerservice.GetPlayerlist().subscribe(
      x => {
        console.log('I am in the first callback of the playerlist observable consumer subscribe...');
        this.playerArr = x;
        //this.filterbywhatever();// call a method if needed
      }, // the first argument ot subscribe handles the successful result of the method call
      y => console.log(`there was an error ${y}`),//the second arg callback func handles an error response
      () => console.log('This is the complete block callback function')// the 3rd callback called "complete" arg always runs (just like a finally lock)
    );
  };

  //filterbywhatever(){}

  PlayerDetails(p: number): void {
    //sort the playerArr for this player
    this.chosenPlayer = this.playerArr?.find(x => x.personId == p);
    // this.chosenPlayer = { personId: 123, fname: '', lname: '', myCountry: 'Russia', street: '123 main', state: 'Texas', city: 'Alvarado', myage: 42000 };
  }
  SortByAgeFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.myage > b.myage) ? 1 : -1);
  }

  SortByFnameFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.fname.toLowerCase() > b.fname.toLowerCase()) ? 1 : -1);
  }

  SortByCountryFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.myCountry.toLowerCase() > b.myCountry.toLowerCase()) ? 1 : -1);
  }

  SortByPersonIdFunc(): void {
    this.playerArr = this.playerArr?.sort((a, b) => (a.personId > b.personId) ? 1 : -1);
  }

  AddPlayerParent(event: Player): void {
    //call the service function to add the player to the Db.
    this.playerservice.AddPlayer(event).subscribe(
      x => this.playerArr?.push(x),
      y => console.log('there was a problem adding the player')
    );

    // this.playerservice.GetPlayerlist().subscribe(
    //   x => {
    //     console.log('I am in the first callback of the playerlist observable consumer subscribe...');
    //     this.playerArr = x;
    //     //this.filterbywhatever();// call a method if needed
    //   }, // the first argument ot subscribe handles the successful result of the method call
    //   y => console.log(`there was an error ${y}`),//the second arg callback func handles an error response
    //   () => console.log('This is the complete block callback function')// the 3rd callback called "complete" arg always runs (just like a finally lock)
    // );
  }

  ReturnsThree(): number {
    return 3;
  }

  ReturnsThreePlusThree(): number {
    return (3 + this.ReturnsThree());
  }

}
