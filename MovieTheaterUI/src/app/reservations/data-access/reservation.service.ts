import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { env } from 'process';
import { Observable } from 'rxjs';
import { ICreateReservationModel } from 'src/app/shared/models/reservation';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  getReservationsByScreeningId(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/screenings/${id}/reservations`);
  }

  getReservationById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/reservations/${id}`);
  }

  getReservationsByUserId(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/users/${id}/reservations`);
  }

  getReservationBySeatScreeningIds(screeningId: string, seatId: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/screenings/${screeningId}/reservations/seats/${seatId}`);
  }

  createReservation(reservation: ICreateReservationModel){
    return this.http.post(`${environment.apiUrl}/screenings/reservations`, reservation);
  }

  changeStatusToPaid(id: string){
    return this.http.put(`${environment.apiUrl}/reservations/${id}/pay`, null);
  }

  cancelReservation(id: string){
    return this.http.delete(`${environment.apiUrl}/reservations/${id}`);
  }
}
