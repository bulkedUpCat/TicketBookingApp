import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductionCountryService } from '../../data-access/production-country.service';

@Component({
  selector: 'app-add-production-country',
  templateUrl: './add-production-country.component.html',
  styleUrls: ['./add-production-country.component.scss']
})
export class AddProductionCountryComponent implements OnInit {
  productionCountryForm: FormGroup;
  constructor(private fb: FormBuilder,
    private productionCountryService: ProductionCountryService,
    private dialogRef: MatDialogRef<AddProductionCountryComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.productionCountryForm = this.fb.group({
      name: [null, [Validators.required]],
      rank: [null, [Validators.required]]
    });
  }

  onSubmit(){
    if (!this.productionCountryForm.valid){
      return;
    }

    this.productionCountryService.createProductionCountry(this.productionCountryForm.value).subscribe(c => {
      this.dialogRef.close();
    }, err => {
      console.log(err);
    });
  }
}
