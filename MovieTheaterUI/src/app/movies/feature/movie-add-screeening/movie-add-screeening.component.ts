import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { MovieLanguageService } from 'src/app/movieLanguages/data-access/movie-language.service';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IMovie } from 'src/app/shared/models/movie';
import { IMovieLanguageModel } from 'src/app/shared/models/movieLanguage';

@Component({
  selector: 'app-movie-add-screeening',
  templateUrl: './movie-add-screeening.component.html',
  styleUrls: ['./movie-add-screeening.component.scss']
})
export class MovieAddScreeeningComponent implements OnInit {
  screeningForm: FormGroup;
  movie: IMovie;
  movieLanguages: IMovieLanguageModel[];
  halls: IHallModel[];

  constructor(private screeningService: ScreeningService,
    private movieLanguageService: MovieLanguageService,
    private hallService: HallService,
    private dialogRef: MatDialogRef<MovieAddScreeeningComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.movie = this.data.movie;
    this.getAllLanguagesOfMovie(this.movie.id);
    this.getAllHalls();
    this.createForm();
  }

  createForm(){
    this.screeningForm = this.fb.group({
      hallId: [null, [Validators.required]],
      startDate: [null, [Validators.required]],
      startTime: [null, [Validators.required]],
      movieLanguageId: [null, [Validators.required]],
      price: [null, [Validators.required]]
    });
  }

  public dateFilter = (d: Date): boolean => {
    const value = this.screeningForm.value;
    return (d >= new Date());
  }

  protected toDate(d: Date | string): Date {
    return (typeof d === 'string') ? new Date(d) : d;
  }

  getAllLanguagesOfMovie(id: string){
    this.movieLanguageService.getAllMovieLanguagesByMovieId(id).subscribe(ml => {
      this.movieLanguages = ml;
      console.log(ml);
    }, err => console.log(err));
  }

  getAllHalls(){
    this.hallService.getAllHalls().subscribe(h => {
      this.halls = h;
    }, err => {
      console.log(err);
    });
  }

  onSubmit(){
    console.log(this.screeningForm.value);
    if (this.screeningForm.invalid){
      return;
    }

    const completeDate = this.combineDateAndTime(this.screeningForm);

    const screening = this.screeningForm.value;
    screening.start = completeDate;
    screening.movieId = this.movie.id;
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
}
