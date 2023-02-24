import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StatisticsService {

  constructor(private http: HttpClient) { }

  getLatestMovies(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/statistics/latest`);
  }

  getLastChanceMovies(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/statistics/lastChance`);
  }
}
