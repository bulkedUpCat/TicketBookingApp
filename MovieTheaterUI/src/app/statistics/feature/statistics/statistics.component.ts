import { Component, OnInit } from '@angular/core';
import { IMovie } from 'src/app/shared/models/movie';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { NotifierService } from 'src/app/shared/services/notifier.service';
import { StatisticsService } from '../../data-access/statistics.service';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss']
})
export class StatisticsComponent implements OnInit {
  latestMovies: IMovie[];
  lastChanceMovies: IMovie[];

  constructor(private statisticsService: StatisticsService,
    private notifier: NotifierService) { }

  ngOnInit(): void {
    this.getLatestMovies();
    this.getLastChanceMovies();
  }

  getLatestMovies(){
    this.statisticsService.getLatestMovies().subscribe(m => {
      this.latestMovies = m;
    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }

  getLastChanceMovies(){
    this.statisticsService.getLastChanceMovies().subscribe(m => {
      this.lastChanceMovies = m;
      //this.lastChanceScreening = m.screenings.sort((a,b) => a.start < b.start ? 1 : -1)[0];
    }, err => this.notifier.showNotification(err.error, 'ERROR'));
  }
}
