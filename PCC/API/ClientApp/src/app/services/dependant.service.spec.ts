import { TestBed } from '@angular/core/testing';

import { DependantService } from './dependant.service';

describe('DependantService', () => {
  let service: DependantService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DependantService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
