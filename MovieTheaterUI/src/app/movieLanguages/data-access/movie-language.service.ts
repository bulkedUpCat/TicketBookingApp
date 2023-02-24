import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateMovieLanguage } from 'src/app/shared/models/movieLanguage';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieLanguageService {

  constructor(private http: HttpClient) { }

  getAllMovieLanguages(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/movieLanguages`);
  }

  getAllMovieLanguagesByMovieId(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/movies/${id}/languages`);
  }

  getMovieLanguageById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/movieLanguages/${id}`);
  }

  createMovieLanguage(model: ICreateMovieLanguage){
    return this.http.post(`${environment.apiUrl}/movieLanguages`, model);
  }
}
