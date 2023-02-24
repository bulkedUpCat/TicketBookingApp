import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieLanguageService } from 'src/app/movieLanguages/data-access/movie-language.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IMovieLanguageModel } from 'src/app/shared/models/movieLanguage';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-movie-add-language',
  templateUrl: './movie-add-language.component.html',
  styleUrls: ['./movie-add-language.component.scss']
})
export class MovieAddLanguageComponent implements OnInit {
  movie: IMovie;
  movieForm: FormGroup;
  movieLanguages: IMovieLanguageModel[];
  chosenLanguages: string[] = [];
  constructor(private movieLanguageService: MovieLanguageService,
    private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MovieAddLanguageComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    this.initLanguages();
    this.getMovieLanguages();
    this.createForm();
  }

  getMovieLanguages(){
    this.movieLanguageService.getAllMovieLanguages().subscribe(l => {
      this.movieLanguages = l;
    }, err => {
      console.log(err);
    });
  }

  onLanguageChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenLanguages.push(id);
    }
    else{
      const index = this.chosenLanguages.indexOf(id);
      if (index > -1){
        this.chosenLanguages.splice(index, 1);
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
      languages: [this.movie.languages.map(g => g.id)]
    });
  }

  onSave(){
    if (!this.movieForm.valid) return;

    const editMovie = this.movieForm.value;
    editMovie.languages = this.chosenLanguages;

    this.movieService.editMovie(this.movie.id, editMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => console.log(err));
  }

  initLanguages(){
    for (let i = 0; i < this.movie.languages.length; i++){
      this.chosenLanguages.push(this.movie.languages[i].id);
    }
  }

  checkLanguages(language: any){
    for (let i = 0; i < this.movie.languages.length; i++){
      if (this.movie.languages[i].name == language) return true;
    }

    return false;
  }
}
