import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductionCompanyService } from 'src/app/productionCompanies/data-access/production-company.service';
import { IMovie } from 'src/app/shared/models/movie';
import { IProductionCompany } from 'src/app/shared/models/productionCompany';
import { MovieService } from '../../data-access/movie.service';

@Component({
  selector: 'app-movie-add-production-company',
  templateUrl: './movie-add-production-company.component.html',
  styleUrls: ['./movie-add-production-company.component.scss']
})
export class MovieAddProductionCompanyComponent implements OnInit {
  i = true;
  movie: IMovie;
  movieForm: FormGroup;
  chosenProductionCompany: string;
  productionCompanies: IProductionCompany[];

  constructor(private productionCompanyService: ProductionCompanyService,
    private movieService: MovieService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<MovieAddProductionCompanyComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }


  ngOnInit(): void {
    this.movie = this.data.movie;
    console.log(this.movie)
    this.getProductionCompanies();
    this.createForm();
  }

  getProductionCompanies(){
    this.productionCompanyService.getProductionCompanies().subscribe(c => {
      this.productionCompanies = c;
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
      productionCompany: [this.movie?.productionCompany?.id]
    });
  }

  onChange(event: any, id: string){
    if (event.currentTarget.checked){
      this.chosenProductionCompany = id;
    }
  }

  onChecked(id: string){
    return this.movie?.productionCompany?.id == id;
  }

  onSave(){
    if (!this.movieForm.valid) return;

    const editMovie = this.movieForm.value;
    editMovie.productionCompany = this.chosenProductionCompany;

    this.movieService.editMovie(this.movie.id, editMovie).subscribe(m => {
      this.dialogRef.close();
    }, err => console.log(err));
  }
}
