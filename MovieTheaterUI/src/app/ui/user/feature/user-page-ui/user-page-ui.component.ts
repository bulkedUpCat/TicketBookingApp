import { Component, OnInit } from '@angular/core';
import { EmailService } from 'src/app/reports/data-access/email.service';
import { ReportService } from 'src/app/reports/data-access/report.service';
import { ReservationService } from 'src/app/reservations/data-access/reservation.service';
import { ScreeningService } from 'src/app/screenings/data-access/screening.service';
import { ReservedSeatService } from 'src/app/seats/data-access/reserved-seat.service';
import { IReservationModel } from 'src/app/shared/models/reservation';
import { IUserModel } from 'src/app/shared/models/user';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { AuthService } from '../../data-access/auth.service';
import { UserService } from '../../data-access/user.service';
import jwt_decode from 'jwt-decode';


@Component({
  selector: 'app-user-page-ui',
  templateUrl: './user-page-ui.component.html',
  styleUrls: ['./user-page-ui.component.scss']
})
export class UserPageUiComponent implements OnInit {
  user: IUserModel;
  reservations: any[];
  reservedSeats: any[];
  displayedReservedSeats: any;
  constructor(private userService: UserService,
    private authService: AuthService,
    private reservationService: ReservationService,
    private reservedSeatService: ReservedSeatService,
    private screeningService: ScreeningService,
    private notifier: NotifierService,
    private reportService: ReportService,
    private emailService: EmailService) { }

  ngOnInit(): void {
    this.authService.getUserInfo().subscribe(u => {
      console.log(u)
      if (u){
        this.getUserById(u.sub);
        this.getReservationsByUserId(u.sub);
      }
    });
  }

  getUserById(id: string){
    this.userService.getUserById(id).subscribe(u => {
      this.user = u;
    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }

  getReservationsByUserId(id: string){
    this.reservationService.getReservationsByUserId(id).subscribe(r => {
      this.reservations = r;
      console.log(r);

      for (let i = 0; i < this.reservations.length; i++){
        this.getScreeningById(this.reservations[i].screeningId, this.reservations[i]);
      }

      for (let i = 0; i < this.reservations.length; i++){
        this.getReservedSeatsByReservationId(this.reservations[i].id, this.reservations[i]);
      }

    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }

  getScreeningById(id: string, reservation: any){
    this.screeningService.getScreeningById(id).subscribe(s => {
      reservation.screening = s;
    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }

  getReservedSeatsByReservationId(id: string, reservation: any){
    this.reservedSeatService.getAllByReservationId(id).subscribe(rs => {
      console.log(rs);
      this.displayedReservedSeats = rs;
      this.reservedSeats = rs;
      reservation.seats = rs;
    })
  }

  onCancelReservation(id: string){
    this.reservationService.cancelReservation(id).subscribe(r => {
      this.getReservationsByUserId(this.user.id);
    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }

  onPrintReservation(id: string){
    this.reportService.printTicketsByReservationId(id).subscribe(r=> {
      let blob = r.body as Blob;
      const file = new Blob([blob], {type: 'application/pdf'});
      const fileURL = URL.createObjectURL(file);
      window.open(fileURL, '_blank', 'width=1000, height=800');
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR');
      console.log(err);
    });
  }

  onSendTickets(id: string){
    let token = localStorage.getItem("auth_token");
    let email = jwt_decode(token)['email'];

    const model: any = {};
    model.email = email;

    this.emailService.sendTickets(id, model).subscribe(e => {
      this.notifier.showNotification('Tickets were sent', 'SUCCESS');
    }, err => {
      this.notifier.showNotification('Something went wrong', 'ERROR');
    });
  }
}
