import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { ReservedSeatService } from 'src/app/seats/data-access/reserved-seat.service';
import { IReservationModel } from 'src/app/shared/models/reservation';
import { IReservedSeatModel } from 'src/app/shared/models/reservedSeat';
import { ISeatModel } from 'src/app/shared/models/seat';
import { ReservationService } from '../../data-access/reservation.service';
import { SendReservationComponent } from '../send-reservation/send-reservation.component';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.scss']
})
export class ReservationComponent implements OnInit {
  reservation: IReservationModel;
  reservedSeats: IReservedSeatModel[] = [];
  reservationStatuses : Record<string, string> = { '0' : 'Active', '1' : 'Canceled', '2' : 'Paid' };

  constructor(private route: ActivatedRoute,
    private reservationService: ReservationService,
    private reservedSeatService: ReservedSeatService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getReservationById(id);
    })
  }

  getReservationById(id: string){
    this.reservationService.getReservationById(id).subscribe(r => {
      this.reservation = r;
      console.log(this.reservation)
      this.getReservedSeats(this.reservation.reservedSeats);
    });
  }

  getReservedSeats(reservedSeats: string[]){
    for (let i = 0; i < reservedSeats.length; i++){
      this.reservedSeatService.getReservedSeatById(reservedSeats[i]).subscribe(rs => {
        let reservedSeat: IReservedSeatModel = rs;
        this.reservedSeats.push(reservedSeat);
      })
    }
  }

  onSendEmail(){
    this.dialog.open(SendReservationComponent,{
      data: {
        id: this.reservation.id
      }
    });
  }
}
