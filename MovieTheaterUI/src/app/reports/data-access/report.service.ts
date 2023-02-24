import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private http: HttpClient) { }

  printTicketsByReservationId(id: string){
    let headers = new HttpHeaders();
    headers = headers.set('Accept', 'application/pdf');

    return this.http.get(`${environment.apiUrl}/reports/reservations/${id}`, {
      observe: 'response',
      responseType: 'blob',
      headers: headers
    });
  }

  printAllMovies(){
    let headers = new HttpHeaders();
    headers = headers.set('Accept', 'application/pdf');

    return this.http.get(`${environment.apiUrl}/reports/movies`, {
      observe: 'response',
      responseType: 'blob',
      headers: headers
    });
  }
}
