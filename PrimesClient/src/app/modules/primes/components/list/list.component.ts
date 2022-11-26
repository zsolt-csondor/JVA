import { Component, Input } from '@angular/core';
import { PrimesService } from 'src/app/core/services/primes.service';

@Component({
  selector: 'app-primes-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {

  constructor(private primesService: PrimesService) {
  }

  public primes?: number[];
  public errorMessage: string = "";

  getPrimeListButtonClick(inputLimit: string): void
  {
    let limit: number = Number(inputLimit);
    this.primesService.getPrimesList(limit).subscribe(this.primeObserver);
  }

  primeObserver: any = {
    next: (res: number[]) => {this.primes = res; this.errorMessage = "";},
    error: (err: any) => {this.errorMessage = err.error.toString(); this.primes = undefined;}
  };

}
