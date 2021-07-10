import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../player';
import { PlayerserviceService } from '../playerservice.service';

@Component({
  selector: 'app-playerdetails',
  templateUrl: './playerdetails.component.html',
  styleUrls: ['./playerdetails.component.css']
})
export class PlayerdetailsComponent implements OnInit {
  @Input() player?: Player;

  constructor(private playerservice: PlayerserviceService) { }

  ngOnInit(): void {
    // do here in ng oninit ONLY initial setup for the class.
    this.playerservice.GetPlayerlist().subscribe(/**
      handle succesful request
      on multiple lines if needed,
      to filter the result,
      or add someting,
      or anyhtins yo9u wnat 
      do it here.
      , handle errors, cleanup */);
  }

}
