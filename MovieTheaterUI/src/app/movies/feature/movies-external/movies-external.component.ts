import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IMovie } from 'src/app/shared/models/movie';
import { MovieService } from '../../data-access/movie.service';
import { MovieExternalDetailComponent } from '../../movie-external-detail/movie-external-detail.component';

@Component({
  selector: 'app-movies-external',
  templateUrl: './movies-external.component.html',
  styleUrls: ['./movies-external.component.scss']
})
export class MoviesExternalComponent implements OnInit {
  movies: any;
  constructor(private movieService: MovieService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(){
    this.movieService.getExternalMovies().subscribe(m => {
      this.movies = m;
    }, err => console.log(err));
  }

  openMovieDetails(movie: any){
    const dialogRef = this.dialog.open(MovieExternalDetailComponent, {
      data: {
        movie: movie
      }
    });
  }
}
