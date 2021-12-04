import { TestBed } from '@angular/core/testing';

import { CalculateDeductionsService } from './calculate-deductions.service';

describe('CalculateDeductionsService', () => {
  let service: CalculateDeductionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculateDeductionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
