import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IMovieLanguageModel } from 'src/app/shared/models/movieLanguage';
import { MovieLanguageService } from '../../data-access/movie-language.service';
import { AddMovieLanguageComponent } from '../add-movie-language/add-movie-language.component';

@Component({
  selector: 'app-movie-languages',
  templateUrl: './movie-languages.component.html',
  styleUrls: ['./movie-languages.component.scss']
})
export class MovieLanguagesComponent implements OnInit {
  movieLanguages: IMovieLanguageModel[];
  constructor(private movieLanguageService: MovieLanguageService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getAllMovieLanguages();
  }

  getAllMovieLanguages(){
    this.movieLanguageService.getAllMovieLanguages().subscribe(l => {
      this.movieLanguages = l;
      console.log(l);
    })
  }

  onAddMovieLanguage(){
    const dialogRef = this.dialog.open(AddMovieLanguageComponent, {
      width: '400px'
    })

    dialogRef.afterClosed().subscribe(m => {
      this.getAllMovieLanguages();
    });
  }
}
