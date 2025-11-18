import { TestBed } from '@angular/core/testing';

import { kafkerTitleStrategy } from './kafker-title-strategy';

describe('kafkerTitleStrategy', () => {
  let service: kafkerTitleStrategy;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(kafkerTitleStrategy);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
