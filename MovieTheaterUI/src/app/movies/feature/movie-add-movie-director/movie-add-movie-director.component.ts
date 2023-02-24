import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieDirectorService } from 'src/app/movieDirectors/data-access/movie-director.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IMovieDirectorModel } from 'src/app/shared/models/movieDirector';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-movie-add-movie-director',
  templateUrl: './movie-add-movie-director.component.html',
  styleUrls: ['./movie-add-movie-director.component.scss']
})
export class MovieAddMovieDirectorComponent implements OnInit {
  movie: IMovie;
  movieForm: FormGroup;
  chosenMovieDirector: string;
  movieDirectors: IMovieDirectorModel[];

  constructor(private movieDirectorService: MovieDirectorService,
    private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MovieAddMovieDirectorComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    this.getMovieDirectors();
    this.createForm();
  }

  getMovieDirectors(){
    this.movieDirectorService.getMovieDirectors().subscribe(d => {
      this.movieDirectors = d;
      console.log(this.movieDirectors)
    }, err => console.log(err));
  }

  createForm(){
    this.movieForm = this.fb.group({
      title: [this.movie.title],
      description: [this.movie.description],
      durationMinutes: [this.movie.durationMinutes],
      dateReleased: [this.movie.dateReleased],
      budget: [this.movie.budget],
      imDbRating: [this.movie.imDbRating],
      revenue: [this.movie.revenue],
      poster: [this.movie.poster],
      movieDirector: [this.movie?.movieDirector?.id]
    });
  }

  onChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenMovieDirector = id;
    }
  }

  onChecked(id: string){
    return this.movie?.movieDirector?.id == id;
  }

  onSave(){
    if (!this.movieForm.valid) return;

    const editMovie = this.movieForm.value;
    editMovie.movieDirector = this.chosenMovieDirector;

    this.movieService.editMovie(this.movie.id, editMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => console.log(err));
  }
}
