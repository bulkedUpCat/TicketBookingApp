import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICreateMovie, IMovie, IMovieModel } from 'src/app/shared/models/movie';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { MovieService } from '../data-access/movie.service';

@Component({
  selector: 'app-movie-external-detail',
  templateUrl: './movie-external-detail.component.html',
  styleUrls: ['./movie-external-detail.component.scss']
})
export class MovieExternalDetailComponent implements OnInit {
  movie: IMovie;
  constructor(private movieService: MovieService,
    private notifier: NotifierService,
    private dialogRef: MatDialogRef<MovieExternalDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
  }

  onAddMovie(){
    let createdMovie: any = {};
    createdMovie.title = this.movie.title;
    createdMovie.description = this.movie.description;
    createdMovie.dateReleased = this.movie.dateReleased;
    createdMovie.poster = this.movie.poster;

    this.movieService.createMovie(createdMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR')
      this.dialogRef.close();
    });
  }
}
