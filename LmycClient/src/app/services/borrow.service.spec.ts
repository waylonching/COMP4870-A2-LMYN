import { TestBed, inject } from '@angular/core/testing';

import { BorrowService } from './borrow.service';

describe('BorrowService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BorrowService]
    });
  });

  it('should be created', inject([BorrowService], (service: BorrowService) => {
    expect(service).toBeTruthy();
  }));
});
