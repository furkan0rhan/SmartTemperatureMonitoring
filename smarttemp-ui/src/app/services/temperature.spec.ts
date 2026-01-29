import { TestBed } from '@angular/core/testing';

import { Temperature } from './temperature';

describe('Temperature', () => {
  let service: Temperature;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Temperature);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
