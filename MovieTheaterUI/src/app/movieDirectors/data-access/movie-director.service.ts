import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieDirectorService {

  constructor(private http: HttpClient) { }

  getMovieDirectors(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/movieDirectors`);
  }
}
