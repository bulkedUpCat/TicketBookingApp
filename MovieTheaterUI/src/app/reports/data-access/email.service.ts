import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmailService {

  constructor(private http: HttpClient) { }

  sendMoviesReport(model: any){
    return this.http.post(`${environment.apiUrl}/email/reports/movies`, model);
  }

  sendTickets(id: string, model: any){
    return this.http.post(`${environment.apiUrl}/email/reports/reservations/${id}`, model)
  }
}
