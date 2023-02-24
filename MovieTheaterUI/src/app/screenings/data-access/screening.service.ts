import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from 'process';
import { Observable } from 'rxjs';
import { ICreateScreeningModel } from 'src/app/shared/models/screening';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  constructor(private http: HttpClient) { }

  getScreeningsByHallId(hallId: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/halls/${hallId}/screenings`);
  }

  getScreeningById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/screenings/${id}`);
  }

  createScreening(screening: ICreateScreeningModel){
    return this.http.post(`${environment.apiUrl}/halls/screenings`, screening);
  }

  deleteScreening(id: string){
    return this.http.delete(`${environment.apiUrl}/screenings/${id}`);
  }
}
