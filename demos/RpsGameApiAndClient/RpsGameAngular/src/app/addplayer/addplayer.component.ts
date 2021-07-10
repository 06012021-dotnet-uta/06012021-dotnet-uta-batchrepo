import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Player } from '../player';

@Component({
  selector: 'app-addplayer',
  templateUrl: './addplayer.component.html',
  styleUrls: ['./addplayer.component.css']
})
export class AddplayerComponent implements OnInit {
  newPlayer: Player = {
    personId: 0,
    fname: '',
    lname: '',
    myCountry: '',
    street: '',
    state: '',
    city: '',
    myage: 0
  };
  @Output() playerevent = new EventEmitter<Player>();
  constructor() { }

  ngOnInit(): void {
  }

  AddNewPlayer(): void {
    this.playerevent.emit(this.newPlayer);
  }

}
