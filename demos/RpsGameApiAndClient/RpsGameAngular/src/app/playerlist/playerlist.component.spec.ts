import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
// import { Observable, of } from 'rxjs';
// import { Player } from '../player';
import { PlayerserviceService } from '../playerservice.service';
import { mockPlayerList } from './MockPlayerList';
import { MockPlayerService } from './MockPlayerServiceClass';

import { PlayerlistComponent } from './playerlist.component';

describe('PlayerlistComponent', () => {
  let component: PlayerlistComponent;
  let fixture: ComponentFixture<PlayerlistComponent>;


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientModule],//add HttpCLient Module to quiet bugs
      declarations: [PlayerlistComponent],
      providers:
        [//add providers
          {
            provide: PlayerserviceService, useClass: MockPlayerService
          }
        ]
    }).compileComponents();
    fixture = TestBed.createComponent(PlayerlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

  });

  // beforeEach(() => {

  // });

  it('should use ngOnInit to get the player list.', () => {
    expect(component.playerArr?.length).toBe(8);
  });

  it('should use ngOnInit to get the player list.', () => {
    if (component.playerArr) {
      expect(component.playerArr[0].fname).toBe('Matt');
    }
  });

  it('PlayerDetails should display the requested player', () => {
    expect(component.chosenPlayer).toBeFalsy;
    component.PlayerDetails(mockPlayerList[3].personId);
    expect(component.chosenPlayer?.myCountry).toContain('S');
  });

  it('should order the PlayerArray by age asc', () => {
    expect(component.chosenPlayer).toBeTruthy;
    if (component.playerArr) {
      expect(component.playerArr[0].personId).toBe(123);
    }
    component.SortByAgeFunc();
    if (component.playerArr) {
      expect(component.playerArr[0].personId).toBe(56);
    }
  });

  it('should add the correct player to the list', () => {
    let p1 = {
      personId: 123,
      fname: 'Edward',
      lname: 'Norton',
      myCountry: 'Brazil',
      street: '953 HulkSmash Ln',
      state: 'NY',
      city: 'NYC',
      myage: 49
    }
    expect(component.playerArr?.find(x => x.fname === 'Edward')).toBeFalsy;
    component.AddPlayerParent(p1);
    expect(component.playerArr?.find(x => x.fname === 'Edward')).toBeTruthy;
  });

  // it('shall return a 5 from Returns3()', () => {
  //   spyOnProperty(component, "ReturnsThree", "get").and.returnValue(5);
  //   let result = component.ReturnsThreePlusThree();
  //   expect(result).toBe(8);
  // });


  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
