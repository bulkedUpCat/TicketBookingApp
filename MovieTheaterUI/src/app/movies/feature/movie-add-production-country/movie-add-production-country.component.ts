import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductionCountryService } from 'src/app/productionCountries/data-access/production-country.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IProductionCountryModel } from 'src/app/shared/models/productionCountry';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-movie-add-production-country',
  templateUrl: './movie-add-production-country.component.html',
  styleUrls: ['./movie-add-production-country.component.scss']
})
export class MovieAddProductionCountryComponent implements OnInit {
  movie: IMovie;
  movieForm: FormGroup;
  countries: IProductionCountryModel[];
  chosenCountries: string[] = [];
  constructor(
    private productionCountryService: ProductionCountryService,
    private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MovieAddProductionCountryComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    this.initCountries();
    this.getCountries();
    this.createForm();
  }

  getCountries(){
    this.productionCountryService.getProductionCountries().subscribe(c => {
      this.countries = c;
    }, err => {
      console.log(err);
    });
  }

  onCountryChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenCountries.push(id);
    }
    else{
      const index = this.chosenCountries.indexOf(id);
      if (index > -1){
        this.chosenCountries.splice(index, 1);
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
      countries: [this.movie.countries.map(c => c.id)]
    });
  }

  onSave(){
    if (!this.movieForm.valid) return;

    const editMovie = this.movieForm.value;
    editMovie.countries = this.chosenCountries;
    console.log(this.chosenCountries);

    this.movieService.editMovie(this.movie.id, editMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => console.log(err));
  }

  initCountries(){
    for (let i = 0; i < this.movie.countries.length; i++){
      this.chosenCountries.push(this.movie.countries[i].id);
    }
  }

  checkCountries(country: any){
    for (let i = 0; i < this.movie.countries.length; i++){
      if (this.movie.countries[i].name == country) return true;
    }

    return false;
  }
}
