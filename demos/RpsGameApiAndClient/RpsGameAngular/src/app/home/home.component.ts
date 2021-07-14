import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    const squareOdd = of(1, 2, 3, 4, 5)
      .pipe(// pipe allows you to enter a series of functions that each element (if there are multiple) through.
        filter(n => n % 2 !== 0),//a function that each element gets sent through
        map(n => n * n)// another function that each element is sent through
        //the array is returned after all elements have passsed through all the listed functions
      );

    squareOdd.subscribe(x => console.log(x));
  }

}
