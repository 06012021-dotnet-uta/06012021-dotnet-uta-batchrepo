import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { PlayerserviceService } from './playerservice.service';

describe('PlayerserviceService', () => {
  let service: PlayerserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
    });
    service = TestBed.inject(PlayerserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
