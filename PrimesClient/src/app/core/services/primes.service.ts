import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PrimesService {

  private primesBaseUrl: string = "https://localhost:5000/api/primes";

  constructor(private http: HttpClient) { }

  getPrimesList(limit: number): Observable<number[]>
  {
    return this.http.get<number[]>(`${this.primesBaseUrl}/list?limit=${limit}`);
  }
}
