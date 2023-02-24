import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { MovieService } from '../../data-access/movie.service';
import { MovieAddGenreComponent } from '../movie-add-genre/movie-add-genre.component';
import { MovieAddLanguageComponent } from '../movie-add-language/movie-add-language.component';
import { MovieAddMovieDirectorComponent } from '../movie-add-movie-director/movie-add-movie-director.component';
import { MovieAddProductionCompanyComponent } from '../movie-add-production-company/movie-add-production-company.component';
import { MovieAddProductionCountryComponent } from '../movie-add-production-country/movie-add-production-country.component';
import { MovieAddScreeeningComponent } from '../movie-add-screeening/movie-add-screeening.component';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {
  movie: IMovie;
  screenings: IScreeningModel[] = [];
  showActiveScreenings: boolean;

  constructor(private route: ActivatedRoute,
    private movieService: MovieService,
    private screeningService: ScreeningService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getMovieById(id);
    })
  }

  getScreenings(){
    this.screenings = [];
    for (let i = 0; i < this.movie.screenings.length; i++){
      this.screeningService.getScreeningById(this.movie.screenings[i].id).subscribe(s => {
        let screening: IScreeningModel = s;
        this.screenings.push(screening);
      });
    }
  }

  getMovieById(id: string){
    this.movieService.getMovieById(id).subscribe(m => {
      this.movie = m;
      console.log(this.movie)
      this.getScreenings();
    })
  }

  onToggleScreenings(){
    this.showActiveScreenings = !this.showActiveScreenings;
  }

  onAddGenre(){
    const dialogRef = this.dialog.open(MovieAddGenreComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }

  onAddCountry(){
    const dialogRef = this.dialog.open(MovieAddProductionCountryComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }

  onAddProductionCompany(){
    const dialogRef = this.dialog.open(MovieAddProductionCompanyComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }

  onAddMovieDirector(){
    const dialogRef = this.dialog.open(MovieAddMovieDirectorComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }

  onAddLanguage(){
    const dialogRef = this.dialog.open(MovieAddLanguageComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }

  onAddScreening(){
    const dialogRef = this.dialog.open(MovieAddScreeeningComponent, {
      width: '400px',
      data: {
        movie: this.movie
      }
    });

    dialogRef.afterClosed().subscribe(_ => {
      this.getMovieById(this.movie?.id);
    });
  }
}
