import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { ReservationService } from 'src/app/reservations/data-access/reservation.service';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { CreateReservationModel, ICreateReservationModel } from 'src/app/shared/models/reservation';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { ISeatModel } from 'src/app/shared/models/seat';
import { AuthService } from 'src/app/ui/user/data-access/auth.service';
import { SeatService } from '../../data-access/seat.service';

@Component({
  selector: 'app-seat-display',
  templateUrl: './seat-display.component.html',
  styleUrls: ['./seat-display.component.scss']
})
export class SeatDisplayComponent implements OnInit {
  @Input() hallId;
  @Input() screeningId;
  screening: IScreeningModel;
  hall: IHallModel;
  seats: ISeatModel[] = [];
  price: number = 0;
  userId: string;
  chosenSeats: string[] = [];

  constructor(private seatService: SeatService,
    private hallService: HallService,
    private reservationService: ReservationService,
    private screeningService: ScreeningService,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.authService.getUserInfo().subscribe(u => {
      if (u){
        this.userId = u.sub;
      }
    });
    console.log(this.screeningId);
    this.getSeats();
    this.getHallById();
    this.getScreeningById();
  }

  getSeats(){
    this.seatService.getAllSeatsByHallId(this.hallId).subscribe(s => {
      this.seats = s;
      this.markStatus();
    });
  }

  getHallById(){
    this.hallService.getHallById(this.hallId).subscribe(h => {
      this.hall = h;
    });
  }

  getScreeningById(){
    this.screeningService.getScreeningById(this.screeningId).subscribe(s => {
      this.screening = s;
    });
  }

  markStatus(){
    for (let i = 0; i < this.seats.length; i++){
      if (this.seats[i].reservedScreenings.includes(this.screeningId)){
        this.seats[i].status = 2; // Set status to occupied
      }
      else{
        this.seats[i].status = 1;
      }
    }
  }

  onSelected(seat: ISeatModel){
    if (seat.status == 0){
      seat.status = 1;
      let index = this.chosenSeats.indexOf(seat.id);
      this.chosenSeats.splice(index, 1);
    }
    else if (seat.status == 1){
      seat.status = 0;

      this.chosenSeats.push(seat.id);
    }
    else{
      this.getReservation(seat.id);
    }

    this.price = this.chosenSeats.length * this.screening.price;
  }

  filterSeats(row: number){
    return this.seats.filter(s => {
      return s.row == row;
    })
  }

  getReservation(seatId: string){
    this.reservationService.getReservationBySeatScreeningIds(this.screeningId, seatId).subscribe(r => {
      this.router.navigateByUrl(`admin/reservations/${r.id}`);
    })
  }

  onBook(){
    console.log(this.chosenSeats);
    var reservationModel: ICreateReservationModel = new CreateReservationModel();
    reservationModel.userId = this.userId;
    reservationModel.screeningId = this.screening.id;
    reservationModel.seatIds = this.chosenSeats;

    this.reservationService.createReservation(reservationModel).subscribe(r => {
      this.price = 0;
      this.chosenSeats = [];
      this.getSeats();
    }, err => {
      console.log(err);
    });
  }
}
