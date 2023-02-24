import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateGenre } from 'src/app/shared/models/genre';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  constructor(private http: HttpClient) { }

  getAllGenres(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/genres`);
  }

  createGenre(genre: ICreateGenre){
    return this.http.post(`${environment.apiUrl}/genres`, genre);
  }
}
