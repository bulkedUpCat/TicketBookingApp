import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { ReservationService } from 'src/app/reservations/data-access/reservation.service';
import { ReservedSeatService } from 'src/app/seats/data-access/reserved-seat.service';
import { SeatService } from 'src/app/seats/data-access/seat.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IReservedSeatModel } from 'src/app/shared/models/reservedSeat';
import { ISeatModel } from 'src/app/shared/models/seat';

@Component({
  selector: 'app-seats-ui',
  templateUrl: './seats-ui.component.html',
  styleUrls: ['./seats-ui.component.scss']
})
export class SeatsUiComponent implements OnInit {
  @Input() hallId;
  @Input() screeningId;
  @Output() seatIdEvent = new EventEmitter<{seatId: string, price: number, action: boolean}>();
  reservedSeats: IReservedSeatModel[];
  hall: IHallModel;
  seats: ISeatModel[] = [];

  constructor(private seatService: SeatService,
    private hallService: HallService,
    private reservationService: ReservationService,
    private reservedSeatService: ReservedSeatService,
    private router: Router) { }

  ngOnInit(): void {
    this.getSeats();
    this.getHallById();
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

  markStatus(){
    console.log(this.screeningId)
    for (let i = 0; i < this.seats.length; i++){
      if (this.seats[i].reservedScreenings.includes(this.screeningId)){
        this.seats[i].status = 2; // Set status to occupied
      }
      else{
        this.seats[i].status = 0;
      }
    }

    console.log(this.seats);
  }

  onSelected(seat: ISeatModel){
    if (seat.status == 0){
      seat.status = 1;
      this.seatIdEvent.emit({seatId: seat.id, price: seat.priceOffset, action: true});
    }
    else if (seat.status == 1){
      seat.status = 0;
      this.seatIdEvent.emit({seatId: seat.id, price: seat.priceOffset, action: false});
    }
  }

  filterSeats(row: number){
    return this.seats.filter(s => {
      return s.row == row;
    })
  }

  getReservedSeats(id: string){
    this.reservedSeatService.getAllByScreeningId(id).subscribe(rs => {
      this.reservedSeats = rs;
      console.log(rs);
    }, err => {
      console.log(err);
    });
  }
}
