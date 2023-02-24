import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IHall } from 'src/app/shared/models/hall';
import { HallService } from '../../data-access/hall.service';

@Component({
  selector: 'app-add-hall',
  templateUrl: './add-hall.component.html',
  styleUrls: ['./add-hall.component.scss']
})
export class AddHallComponent implements OnInit {
  public hallForm: FormGroup;

  constructor(private dialogRef: MatDialogRef<AddHallComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private hallService: HallService) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.hallForm = this.fb.group({
      name: [null, [Validators.required]],
      seatsNumber: [null, [Validators.required]],
      seatsInRow: [null, [Validators.required]],
      seatPrice: [null, [Validators.required]]
    });
  }

  onCancel(){
    this.dialogRef.close();
  }

  onSubmit(){
    if (this.hallForm.invalid){
      return;
    }

    const hall: IHall = this.hallForm.value;

    this.hallService.createHall(hall).subscribe(h => {
      this.dialogRef.close();
    });
  }
}
