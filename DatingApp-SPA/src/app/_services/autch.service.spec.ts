/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AutchService } from './autch.service';

describe('Service: Autch', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AutchService]
    });
  });

  it('should ...', inject([AutchService], (service: AutchService) => {
    expect(service).toBeTruthy();
  }));
});
