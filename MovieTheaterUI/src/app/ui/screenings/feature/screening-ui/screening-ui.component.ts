import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { MovieLanguageService } from 'src/app/movieLanguages/data-access/movie-language.service';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IMovieLanguageModel } from 'src/app/shared/models/movieLanguage';
import { IScreeningModel } from 'src/app/shared/models/screening';

@Component({
  selector: 'app-screening-ui',
  templateUrl: './screening-ui.component.html',
  styleUrls: ['./screening-ui.component.scss']
})
export class ScreeningUiComponent implements OnInit {
  screening: IScreeningModel;
  dataLoaded: boolean = false;
  totalPrice: number = 0;
  seats: string[] = [];
  movieLanguage: IMovieLanguageModel;
  hall: IHallModel;

  constructor(private route: ActivatedRoute,
    private screeningService: ScreeningService,
    private movieLanguageService: MovieLanguageService,
    private hallService: HallService,
    private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getScreeningById(id);
    })
  }

  getScreeningById(id: string){
    this.screeningService.getScreeningById(id).subscribe(s => {
      this.dataLoaded = true;
      this.screening = s;
      this.getHallById(this.screening.hallId);
      this.getMovieLanguageById(this.screening.movieLanguageId);
    }, err => {
      console.log(err);
    });
  }

  getMovieLanguageById(id: string){
    this.movieLanguageService.getMovieLanguageById(id).subscribe(ml => {
      this.movieLanguage = ml;
    }, err => {
      console.log(err);
    });
  }

  getHallById(id: string){
    this.hallService.getHallById(id).subscribe(h => {
      this.hall = h;
    }, err => {
      console.log(err);
    });
  }

  onToggleSeat(event: any){
    if (event.action){
      this.seats.push(event.seatId);
      this.totalPrice += this.screening.price;
    }
    else{
      const index = this.seats.indexOf(event.seatId);
      if (index > -1){
        this.seats.splice(index, 1);
      }
      this.totalPrice -= this.screening.price;
    }
  }

  onBook(){
    if (this.seats.length == 0) return;

    this.router.navigate(['/reservations/' + this.screening.id], {state: { seats: this.seats, price: this.totalPrice }});
  }
}
