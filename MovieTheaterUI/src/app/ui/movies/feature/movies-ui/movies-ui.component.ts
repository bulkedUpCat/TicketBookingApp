import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GenreService } from 'src/app/genres/data-access/genre.service';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { ProductionCompanyService } from 'src/app/productionCompanies/data-access/production-company.service';
import { ProductionCountryService } from 'src/app/productionCountries/data-access/production-country.service';
import { EmailService } from 'src/app/reports/data-access/email.service';
import { ReportService } from 'src/app/reports/data-access/report.service';
import { IGenre } from 'src/app/shared/models/genre';
import { IMovie, IMovieFilter, MovieFilter } from 'src/app/shared/models/movie';
import { IProductionCompany } from 'src/app/shared/models/productionCompany';
import { IProductionCountryModel } from 'src/app/shared/models/productionCountry';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import jwt_decode from 'jwt-decode';
import { AuthService } from 'src/app/ui/user/data-access/auth.service';

@Component({
  selector: 'app-movies-ui',
  templateUrl: './movies-ui.component.html',
  styleUrls: ['./movies-ui.component.scss']
})
export class MoviesUiComponent implements OnInit {
  movies: IMovie[];
  genres: IGenre[];
  productionCompanies: IProductionCompany[];
  countries: IProductionCountryModel[];
  searchString: string = "";
  durationOptions: number[] = [60, 90, 100, 120];
  sortingOptions: string[] = ['Runtime', 'Release date', 'Title', 'IMDb rating']
  filter: IMovieFilter = new MovieFilter();

  constructor(private movieService: MovieService,
    private genreService: GenreService,
    private route: ActivatedRoute,
    private router: Router,
    public authService: AuthService,
    private productionCompanyService: ProductionCompanyService,
    private countryService: ProductionCountryService,
    private reportService: ReportService,
    private emailService: EmailService,
    private notifier: NotifierService)
    {
      if (route.snapshot.params['genres']){
        let g = route.snapshot.params['genres'];
        this.filter.genres = g.split(',');
      }

      if (route.snapshot.params['runtime']){
        let r = route.snapshot.params['runtime'];
        this.filter.runtime = r.split(',');
      }

      if (route.snapshot.params['companies']){
        let c = route.snapshot.params['companies'];
        this.filter.companies = c.split(',');
      }

      if (route.snapshot.params['countries']){
        let c = route.snapshot.params['countries'];
        this.filter.countries = c.split(',');
      }

      if (route.snapshot.params['sortingOption']){
        let s = route.snapshot.params['sortingOption'];
        this.filter.sortingOption = s;
      }

      if (route.snapshot.params['title']){
        this.filter.title = route.snapshot.params['title'];
        this.searchString = this.filter.title;
      }
      else{
        this.filter.title = this.searchString;
      }
    }

  ngOnInit(): void {
    this.getMovies(this.filter);
    this.getGenres();
    this.getProductionCompanies();
    this.getProductionCountries();
  }

  getMovies(filter){
    this.movieService.getMovies(filter).subscribe(m => {
      this.movies = m.movies;
    }, err => {
      console.log(err);
    })
  }

  onSearch(str){
    if (str == undefined) return;
    this.filter.title = str;
    this.getMovies(this.filter);
    this.applyFilter();
  }

  getGenres(){
    this.genreService.getAllGenres().subscribe(g => {
      this.genres = g;
    }, err => {
      console.log(err);
    });
  }

  onGenreChangeFilter(event: any, genre: IGenre){
    if (event.currentTarget.checked){
      this.filter.genres.push(genre.name);
      this.getMovies(this.filter);
      this.applyFilter();
    }
    else{
      const index = this.filter.genres.indexOf(genre.name);

      if (index > -1){
        this.filter.genres.splice(index, 1);
        this.getMovies(this.filter);
        this.applyFilter();
      }
    }
  }

  onRuntimeFilterChange(event: any, runtime){
    if (event.currentTarget.checked){
      this.filter.runtime.push(runtime.toString());
      this.getMovies(this.filter);
      this.applyFilter();
    }
    else{
      const index = this.filter.runtime.indexOf(runtime.toString());

      if (index > -1){
        this.filter.runtime.splice(index, 1);
        this.getMovies(this.filter);
        this.applyFilter();
      }
    }
  }

  getProductionCompanies(){
    this.productionCompanyService.getProductionCompanies().subscribe(c => {
      this.productionCompanies = c;
    }, err => console.log(err));
  }

  onProductionCompanyChange(event: any, company: IProductionCompany){
    if (event.currentTarget.checked){
      this.filter.companies.push(company?.name);
      this.getMovies(this.filter);
      this.applyFilter();
    }
    else{
      const index = this.filter.companies.indexOf(company?.name);

      if (index > -1){
        this.filter.companies.splice(index, 1);
        this.getMovies(this.filter);
        this.applyFilter();
      }
    }
  }

  getProductionCountries(){
    this.countryService.getProductionCountries().subscribe(c => {
      this.countries = c;
    }, err => console.log(err));
  }

  onCountryFilterChange(event: any, country: IProductionCountryModel){
    if (event.currentTarget.checked){
      this.filter.countries.push(country?.name);
      this.getMovies(this.filter);
      this.applyFilter();
    }
    else{
      const index = this.filter.countries.indexOf(country?.name);

      if (index > -1){
        this.filter.countries.splice(index, 1);
        this.getMovies(this.filter);
        this.applyFilter();
      }
    }
  }

  onSortingOptionChange(event: any, sorting){
    this.filter.sortingOption = sorting;
    this.getMovies(this.filter);
    this.applyFilter();
  }

  onResetSort(){
    this.filter.sortingOption = null;
    this.getMovies(this.filter);
    this.applyFilter();
  }

  applyFilter(){
    this.applyFilterToRoute();
  }

  applyFilterToRoute(){
    this.router.navigate(
      [
        {
          title: this.filter.title,
          genres: this.filter.genres,
          runtime: this.filter.runtime,
          companies: this.filter.companies,
          countries: this.filter.countries,
          sortingOption: this.filter.sortingOption
        }
      ],
      {
        relativeTo: this.route,
        replaceUrl: true
      }
    )
  }

  onPrintMovies(){
    this.reportService.printAllMovies().subscribe(r => {
      let blob = r.body as Blob;
      const file = new Blob([blob], {type: 'application/pdf'});
      const fileURL = URL.createObjectURL(file);
      window.open(fileURL, '_blank', 'width=1000, height=800');
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR');
      console.log(err);
    });
  }

  onSendEmailReport(){
    let token = localStorage.getItem("auth_token");
    let email = jwt_decode(token)['email'];

    const model: any = {};
    model.email = email;

    this.emailService.sendMoviesReport(model).subscribe(e => {
      this.notifier.showNotification('Email sent', 'SUCCESS');
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR');
    })
  }
}
