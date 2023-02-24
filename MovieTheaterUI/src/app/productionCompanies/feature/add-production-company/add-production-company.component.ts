import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductionCompanyService } from '../../data-access/production-company.service';

@Component({
  selector: 'app-add-production-company',
  templateUrl: './add-production-company.component.html',
  styleUrls: ['./add-production-company.component.scss']
})
export class AddProductionCompanyComponent implements OnInit {
  productionCompanyForm: FormGroup;
  constructor(private fb: FormBuilder,
    private productionCompanyService: ProductionCompanyService,
    private dialogRef: MatDialogRef<AddProductionCompanyComponent>) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.productionCompanyForm = this.fb.group({
      name: [null, [Validators.required]],
      rank: [null, [Validators.required]]
    });
  }

  onSubmit(){
    if (!this.productionCompanyForm.valid){
      return;
    }

    this.productionCompanyService.createProductionCompany(this.productionCompanyForm.value).subscribe(c => {
      this.dialogRef.close();
    }, err => {
      console.log(err);
    });
  }
}
