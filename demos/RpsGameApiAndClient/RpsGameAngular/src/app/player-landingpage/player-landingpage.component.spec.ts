import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerLandingpageComponent } from './player-landingpage.component';

describe('PlayerLandingpageComponent', () => {
  let component: PlayerLandingpageComponent;
  let fixture: ComponentFixture<PlayerLandingpageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayerLandingpageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerLandingpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
