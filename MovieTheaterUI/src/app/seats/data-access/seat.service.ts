import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeatService {

  constructor(private http: HttpClient) { }

  getAllSeatsByIds(ids: string[]): Observable<any>{
    var parameters = {};

    parameters['ids'] = ids;

    return this.http.get(`${environment.apiUrl}/seats`, { params: parameters });
  }

  getAllSeatsByHallId(hallId: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/halls/${hallId}/seats`);
  }
}
