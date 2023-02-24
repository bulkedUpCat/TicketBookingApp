import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { env } from 'process';
import { Observable } from 'rxjs';
import { ICreateMovie, IEditMovie, IMovie, IMovieFilter, IMovieModel } from 'src/app/shared/models/movie';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getMovies(filter: IMovieFilter): Observable<IMovieModel>{
    var parameters = {};

    if (filter.title) parameters['title'] = filter.title;
    if (filter.runtime) parameters['runtime'] = filter.runtime;
    if (filter.genres) parameters['genres'] = filter.genres;
    if (filter.companies) parameters['companies'] = filter.companies;
    if (filter.countries) parameters['countries'] = filter.countries;
    if (filter.sortingOption) parameters['sortingOption'] = filter.sortingOption;

    return this.http.get<IMovieModel>(`${environment.apiUrl}/movies`, {
      params: parameters
    });
  }

  getExternalMovies(): Observable<IMovieModel>{
    return this.http.get<IMovieModel>(`${environment.apiUrl}/external/movies`);
  }

  getTop3Movies(): Observable<any>{
    return this.http.get<IMovieModel>(`${environment.apiUrl}/movies/top3`);
  }

  getComingOutThisWeekMovies(): Observable<any>{
    return this.http.get<IMovieModel>(`${environment.apiUrl}/movies/top3`);
  }

  getComingSoonMovies(): Observable<any>{
    return this.http.get<IMovieModel>(`${environment.apiUrl}/movies/comingSoon`);
  }

  getMovieById(id: string): Observable<any>{
    return this.http.get(`${environment.apiUrl}/movies/${id}`);
  }

  createMovie(movie: ICreateMovie){
    return this.http.post(`${environment.apiUrl}/movies`, movie);
  }

  editMovie(id: string, movie: IEditMovie){
    return this.http.put(`${environment.apiUrl}/movies/${id}`, movie);
  }

  deleteMovie(id: string){
    return this.http.delete(`${environment.apiUrl}/movies/${id}`);
  }

  executeRawQuery(model: any){
    return this.http.post(`${environment.apiUrl}/movies/raw`, model);
  }
}
