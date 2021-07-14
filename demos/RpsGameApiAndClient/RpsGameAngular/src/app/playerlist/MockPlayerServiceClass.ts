import { Observable, of } from "rxjs";
import { Player } from "../player";
import { mockPlayerList } from "./MockPlayerList";

export class MockPlayerService {
  GetPlayerlist(): Observable<Player[]> {
    // this is where your httpclient GET, POST, etc methods will be
    return of(mockPlayerList);
  }

  AddPlayer(p: Player): Observable<Player> {
    return of(p);
  }
}