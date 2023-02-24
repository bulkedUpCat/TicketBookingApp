import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/movies/data-access/movie.service';
import { NotifierService } from 'src/app/shared/services/notifier.service';

@Component({
  selector: 'app-raw-query',
  templateUrl: './raw-query.component.html',
  styleUrls: ['./raw-query.component.scss']
})
export class RawQueryComponent implements OnInit {
  result: any;
  Object = Object;
  query: string = "";
  queried: boolean = false;
  constructor(private movieService: MovieService,
    private notifier: NotifierService) { }

  ngOnInit(): void {
  }

  onExecute(query: string){
    const model: any = {};
    model.query = query;
    this.movieService.executeRawQuery(model).subscribe(r => {
      this.result = r;
      console.log(r);
      console.log(this.Object.keys(this.result))
      this.queried = true;
      this.notifier.showNotification('Executed', 'SUCCESS');
    }, err => {
      this.notifier.showNotification('Invalid query', 'ERROR');
      console.log(err);
    });
  }
}
