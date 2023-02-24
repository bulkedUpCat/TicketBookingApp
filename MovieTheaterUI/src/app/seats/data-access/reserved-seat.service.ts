import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReservedSeatService {

  constructor(private http: HttpClient) { }

  getReservedSeatById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/reservedSeats/${id}`);
  }

  getAllByScreeningId(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/screenings/${id}/reservedSeats`);
  }

  getAllByReservationId(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/reservations/${id}/reservedSeats`);
  }
}
