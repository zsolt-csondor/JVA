import { HttpClientModule, HttpErrorResponse } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { PrimesService } from 'src/app/core/services/primes.service';

import { ListComponent } from './list.component';

describe('ListComponent', () => {
  let fixture: ComponentFixture<ListComponent>;
  let mockPrimesService : any;

  beforeEach(async () => {
    mockPrimesService = jasmine.createSpyObj(['getPrimesList']);

    TestBed.configureTestingModule({
      declarations: [ListComponent],
      providers: [
        {provide: PrimesService, useValue: mockPrimesService}
      ],
      imports: [HttpClientModule],
    });
    
    fixture = TestBed.createComponent(ListComponent);
  });

  it('should contain no primes upon creation', () => {
    expect(fixture.componentInstance.primes).toBeUndefined();
  });

  it('should have no error messages upon creation', () => {
    expect(fixture.componentInstance.errorMessage).toBe("");
  });

  it('should store the correct prime numbers after calling the service', () => {
    let inputLimit: string = "5";
    let returnedPrimes: number[] = [2,3,5];
    mockPrimesService.getPrimesList.and.returnValue(of(returnedPrimes));

    fixture.componentInstance.getPrimeListButtonClick(inputLimit);

    expect(fixture.componentInstance.primes).toEqual(returnedPrimes);
  });
});
