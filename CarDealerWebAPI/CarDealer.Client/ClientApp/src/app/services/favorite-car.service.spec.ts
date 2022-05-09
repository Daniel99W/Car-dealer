import { TestBed } from '@angular/core/testing';

import { FavoriteCarService } from './favorite-car.service';

describe('FavoriteCarService', () => {
  let service: FavoriteCarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FavoriteCarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
