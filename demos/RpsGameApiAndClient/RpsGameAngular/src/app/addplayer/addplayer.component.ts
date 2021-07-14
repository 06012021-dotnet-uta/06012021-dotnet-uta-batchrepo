import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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

  //a FormGroup os the container fo the FormControl's
  playerForm = new FormGroup({
    //FormControls represent the Properties of the form.
    personId: new FormControl(0, [Validators.min(1)]),
    fname: new FormControl('', [Validators.maxLength(20), Validators.minLength(3)]),
    lname: new FormControl(''),
    myCountry: new FormControl(''),
    street: new FormControl(''),
    state: new FormControl(''),
    city: new FormControl(''),
    myage: new FormControl(0),
  });


  constructor() { }

  ngOnInit(): void {
  }

  AddNewPlayer(): void {
    this.playerevent.emit(this.newPlayer);
  }

  PlayerReactiveFormSubmit(event: MouseEvent): void {
    console.log('The event was triggered')
  }

}
