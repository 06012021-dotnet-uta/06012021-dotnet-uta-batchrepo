import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Player } from './player';
import { mockPlayerList } from './playerlist/MockPlayerList';

@Injectable({
  providedIn: 'root'
})

export class PlayerserviceService {
  url: string = 'https://localhost:5001/api/RpsGame/';
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(private http: HttpClient) { }

  GetPlayerlist(): Observable<Player[]> {
    //returnthe MockPlayerList
    //return of(mockPlayerList);
    return this.http.get<Player[]>('https://localhost:5001/api/RpsGame/PlayerList');
  }

  AddPlayer(p: Player): Observable<Player> {
    //this MAY not be correct
    return this.http.post<Player>(`${this.url}CreateNewPlayer/`, p, this.httpOptions)

  }



  //create any methods that are relevant to this service heres
}
