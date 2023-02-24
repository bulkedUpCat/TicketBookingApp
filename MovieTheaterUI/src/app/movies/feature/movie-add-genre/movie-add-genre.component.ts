import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GenreService } from 'src/app/genres/data-access/genre.service';
import { IGenre } from 'src/app/shared/models/genre';
import { IMovie, IEditMovie } from 'src/app/shared/models/movie';
import { MovieService } from '../../data-access/movie.service';
import { EditMovieComponent } from '../edit-movie/edit-movie.component';

@Component({
  selector: 'app-movie-add-genre',
  templateUrl: './movie-add-genre.component.html',
  styleUrls: ['./movie-add-genre.component.scss']
})
export class MovieAddGenreComponent implements OnInit {
  movie: IMovie;
  movieForm: FormGroup;
  genres: IGenre[];
  chosenGenres: string[] = [];
  constructor(private genreService: GenreService,
    private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MovieAddGenreComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    this.initGenres();
    this.getGenres();
    this.createForm();
  }

  getGenres(){
    this.genreService.getAllGenres().subscribe(g => {
      this.genres = g;
    }, err => {
      console.log(err);
    });
  }

  onGenreChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenGenres.push(id);
    }
    else{
      const index = this.chosenGenres.indexOf(id);
      if (index > -1){
        this.chosenGenres.splice(index, 1);
      }
    }
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
      genres: [this.movie.genres.map(g => g.id)]
    });
  }

  onSave(){
    if (!this.movieForm.valid) return;

    const editMovie = this.movieForm.value;
    editMovie.genres = this.chosenGenres;

    this.movieService.editMovie(this.movie.id, editMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => console.log(err));
  }

  initGenres(){
    for (let i = 0; i < this.movie.genres.length; i++){
      this.chosenGenres.push(this.movie.genres[i].id);
    }
  }

  checkGenres(genre: any){
    for (let i = 0; i < this.movie.genres.length; i++){
      if (this.movie.genres[i].name == genre) return true;
    }

    return false;
  }
}
