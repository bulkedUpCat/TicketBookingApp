import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Navigation, ParamMap, Router } from '@angular/router';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { ReservationService } from 'src/app/reservations/data-access/reservation.service';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { SeatService } from 'src/app/seats/data-access/seat.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IMovieModel } from 'src/app/shared/models/movie';
import { CreateReservationModel, ICreateReservationModel, IReservationModel } from 'src/app/shared/models/reservation';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { ISeatModel } from 'src/app/shared/models/seat';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { AuthService } from 'src/app/ui/user/data-access/auth.service';

@Component({
  selector: 'app-add-reservation-ui',
  templateUrl: './add-reservation-ui.component.html',
  styleUrls: ['./add-reservation-ui.component.scss']
})
export class AddReservationUiComponent implements OnInit {
  userId: string;
  seats: ISeatModel[];
  screening: IScreeningModel;
  movie: IMovieModel;
  hall: IHallModel;
  price: number;
  constructor(private router: Router,
    private route: ActivatedRoute,
    private seatService: SeatService,
    private screeningService: ScreeningService,
    private hallService: HallService,
    private movieService: MovieService,
    private reservationService: ReservationService,
    private authService: AuthService,
    private notifier: NotifierService) {

    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('screeningId')
      this.getScreeningById(id);
    })

    let nav: Navigation = this.router.getCurrentNavigation();

    if (nav.extras && nav.extras.state && nav.extras.state['seats']) {
      let ids = nav.extras.state['seats'];
      this.price = nav.extras.state['price'];
      this.getSeats(ids);
    }
  }

  ngOnInit(): void {
    this.authService.getUserInfo().subscribe(u => {
      if (u){
        this.userId = u.sub;
      }
    });
  }

  getScreeningById(id: string){
    this.screeningService.getScreeningById(id).subscribe(s => {
      this.screening = s;
      this.getMovieById(this.screening.movieId);
      this.getHallById(this.screening.hallId);
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }

  getHallById(id: string){
    this.hallService.getHallById(id).subscribe(h => {
      this.hall = h;
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }

  getMovieById(id: string){
    this.movieService.getMovieById(id).subscribe(m => {
      this.movie = m;
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }

  getSeats(ids){
    this.seatService.getAllSeatsByIds(ids).subscribe(s => {
      this.seats = s;
      console.log(this.seats)
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }

  onBook(){
    var reservationModel: ICreateReservationModel = new CreateReservationModel();
    reservationModel.userId = this.userId;
    reservationModel.screeningId = this.screening.id;
    reservationModel.seatIds = this.seats.map(s => s.id);

    this.reservationService.createReservation(reservationModel).subscribe(r => {
      this.router.navigateByUrl('/home');
    }, err => {
      this.notifier.showNotification(err.error, 'ERROR');
    });
  }
}
