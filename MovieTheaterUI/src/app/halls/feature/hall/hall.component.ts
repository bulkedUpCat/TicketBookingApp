import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { IHallModel } from 'src/app/shared/models/hall';
import { HallService } from '../../data-access/hall.service';

@Component({
  selector: 'app-hall',
  templateUrl: './hall.component.html',
  styleUrls: ['./hall.component.scss']
})
export class HallComponent implements OnInit {
  hall: IHallModel;
  constructor(private hallService: HallService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getHallById(id);
    })
  }

  getHallById(id: string){
    this.hallService.getHallById(id).subscribe(h => {
      this.hall = h;
    });
  }
}
