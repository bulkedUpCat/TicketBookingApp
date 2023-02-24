import { Component, OnInit } from '@angular/core';
import { HallService } from '../../data-access/hall.service';
import { MatDialog } from '@angular/material/dialog';
import { SeatDisplayComponent } from 'src/app/seats/feature/seat-display/seat-display.component';
import { AddHallComponent } from '../add-hall/add-hall.component';
import { IHall, IHallModel } from 'src/app/shared/models/hall';

@Component({
  selector: 'app-halls',
  templateUrl: './halls.component.html',
  styleUrls: ['./halls.component.scss']
})
export class HallsComponent implements OnInit {
  halls: IHallModel[];
  constructor(private hallService: HallService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getAllHalls();
  }

  getAllHalls(){
    this.hallService.getAllHalls().subscribe(h => {
      this.halls = h;
      console.log(h);
    });
  }

  onAddHall(){
    const dialogRef = this.dialog.open(AddHallComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(() => {
      this.getAllHalls();
    });
  }

  onDeleteHall(id: string){
    console.log(id);
    this.hallService.deleteHall(id).subscribe(h => {
      this.getAllHalls();
    });
  }
}
