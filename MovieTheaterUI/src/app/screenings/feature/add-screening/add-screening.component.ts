import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { MovieLanguageService } from 'src/app/movieLanguages/data-access/movie-language.service';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IMovie, IMovieModel, MovieFilter } from 'src/app/shared/models/movie';
import { IMovieLanguageModel } from 'src/app/shared/models/movieLanguage';
import { ScreeningService } from '../../data-access/screening.service';

@Component({
  selector: 'app-add-screening',
  templateUrl: './add-screening.component.html',
  styleUrls: ['./add-screening.component.scss']
})
export class AddScreeningComponent implements OnInit {
  screeningForm: FormGroup;
  movieLanguages: IMovieLanguageModel[];
  movies: IMovie[];

  constructor(private screeningService: ScreeningService,
    private movieLanguageService: MovieLanguageService,
    private movieService: MovieService,
    private dialogRef: MatDialogRef<AddScreeningComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    console.log(this.data)
    this.createForm();
    this.getAllMovies();
  }

  createForm(){
    this.screeningForm = this.fb.group({
      hallId: [this.data.hall.id, [Validators.required]],
      movieId: [null, [Validators.required]],
      startDate: [null, [Validators.required]],
      startTime: [null, [Validators.required]],
      movieLanguageId: [null, [Validators.required]]
    });
  }

  public dateFilter = (d: Date): boolean => {
    const value = this.screeningForm.value;
    return (d >= new Date());
  }

  protected toDate(d: Date | string): Date {
    return (typeof d === 'string') ? new Date(d) : d;
  }

  onSubmit(){
    console.log(this.screeningForm.value);
    if (this.screeningForm.invalid){
      return;
    }

    const completeDate = this.combineDateAndTime(this.screeningForm);

    const screening = this.screeningForm.value;
    screening.start = completeDate;
    console.log(screening);

    this.screeningService.createScreening(screening).subscribe(s => {
      this.dialogRef.close();
    })
  }

  combineDateAndTime(form: FormGroup){
    const date = this.screeningForm.get('startDate').value;
    const time = this.screeningForm.get('startTime').value;

    const t1: any = time.split(' ');
    const t2: number = t1[0].split(':');
    t2[0] = (t1[1] === 'PM' ? (1*t2[0] + 12) : t2[0]);
    const time24 = (t2[0] < 10 ? '0' + t2[0] : t2[0]) + ':' + t2[1];
    const completeDate = date.toString().replace("00:00", time24.toString());

    return new Date(completeDate);
  }

  getAllLanguagesOfMovie(id: string){
    this.movieLanguageService.getAllMovieLanguagesByMovieId(id).subscribe(ml => {
      this.movieLanguages = ml;
      console.log(ml);
    }, err => console.log(err));
  }

  getAllMovies(){
    this.movieService.getMovies(new MovieFilter).subscribe(m => {
      this.movies = m.movies;
      console.log(this.movies)
    }, err => {
      console.log(err);
    });
  }
}
