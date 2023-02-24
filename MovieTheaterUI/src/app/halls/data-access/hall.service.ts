import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { IHall, IHallModel } from 'src/app/shared/models/hall';
import { env } from 'process';

@Injectable({
  providedIn: 'root'
})
export class HallService {

  constructor(private http: HttpClient) { }

  getAllHalls(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/halls`);
  }

  getHallById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/halls/${id}`);
  }

  createHall(hall: IHall){
    return this.http.post(`${environment.apiUrl}/halls`, hall);
  }

  deleteHall(id: string){
    return this.http.delete(`${environment.apiUrl}/halls/${id}`);
  }
}
