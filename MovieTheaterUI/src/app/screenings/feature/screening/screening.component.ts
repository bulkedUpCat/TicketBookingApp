import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ReservationService } from 'src/app/reservations/data-access/reservation.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IReservationModel } from 'src/app/shared/models/reservation';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { ScreeningService } from '../../data-access/screening.service';

@Component({
  selector: 'app-screening',
  templateUrl: './screening.component.html',
  styleUrls: ['./screening.component.scss']
})
export class ScreeningComponent implements OnInit {
  hallId: string;
  screening: IScreeningModel;
  reservations: IReservationModel[] = [];
  showReservations: boolean;
  dataLoaded: boolean = false;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private screeningService: ScreeningService,
    private reservationService: ReservationService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getScreeningById(id);
    })
  }

  getScreeningById(id: string){
    this.screeningService.getScreeningById(id).subscribe(s => {
      this.screening = s;
      this.hallId = this.screening.hallId;
      this.dataLoaded = true;
      this.getReservations();
    });
  }

  getHall(id: string){

  }

  onToggleReservations(){
    this.showReservations = !this.showReservations;
  }

  getReservations(){
    var reservationIds = this.screening.reservations;
    this.reservations = []
    console.log(reservationIds)
    for (let i = 0; i < reservationIds.length; i++){
      this.reservationService.getReservationById(reservationIds[i]).subscribe(r => {
        let reservation: IReservationModel = r;
        this.reservations.push(reservation);
      })
    }
  }

  onConfirmReservation(id: string){
    this.reservationService.changeStatusToPaid(id).subscribe(r => {
      this.getReservations();
    }, err => console.log(err))
  }

  onDeleteScreening(){
    this.screeningService.deleteScreening(this.screening.id).subscribe(s => {
      this.router.navigateByUrl("/admin/halls");
    }, err => {
      console.log(err);
    });
  }
}
