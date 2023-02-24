import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { HallService } from 'src/app/halls/data-access/hall.service';
import { IHallModel } from 'src/app/shared/models/hall';
import { IScreeningModel } from 'src/app/shared/models/screening';
import { ScreeningService } from '../../data-access/screening.service';
import { AddScreeningComponent } from '../add-screening/add-screening.component';

@Component({
  selector: 'app-screenings',
  templateUrl: './screenings.component.html',
  styleUrls: ['./screenings.component.scss']
})
export class ScreeningsComponent implements OnInit {
  displayedColumns: string[] = ['id','movieId', 'movieTitle', 'hallId', 'start'];
  @ViewChild('paginator') paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<IScreeningModel>;
  hall: IHallModel;
  screenings: IScreeningModel[];

  constructor(private hallService: HallService,
    private screeningService: ScreeningService,
    private route: ActivatedRoute,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      let id = params.get('id')
      this.getHallById(id);
      this.getScreeningsByHallId(id);
    })
  }

  getHallById(id: string){
    this.hallService.getHallById(id).subscribe(h => {
      this.hall = h;
    });
  }

  getScreeningsByHallId(hallId: string){
    this.screeningService.getScreeningsByHallId(hallId).subscribe(s => {
      this.screenings = s;
      console.log(s);
      this.dataSource = new MatTableDataSource(this.screenings);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  onAddNew(){
    const dialogRef = this.dialog.open(AddScreeningComponent, {
      data: {
        hall: this.hall
      }
    });

    dialogRef.afterClosed().subscribe(() => {
      this.getScreeningsByHallId(this.hall.id);
    });
  }
}
