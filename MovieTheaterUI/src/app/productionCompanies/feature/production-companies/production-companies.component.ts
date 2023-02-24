import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IProductionCompany } from 'src/app/shared/models/productionCompany';
import { ProductionCompanyService } from '../../data-access/production-company.service';
import { AddProductionCompanyComponent } from '../add-production-company/add-production-company.component';

@Component({
  selector: 'app-production-companies',
  templateUrl: './production-companies.component.html',
  styleUrls: ['./production-companies.component.scss']
})
export class ProductionCompaniesComponent implements OnInit {
  companies: IProductionCompany[];
  constructor(private productionCompanyService: ProductionCompanyService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getProductionCompanies();
  }

  getProductionCompanies(){
    this.productionCompanyService.getProductionCompanies().subscribe(p => {
      this.companies = p;
    }, err => {
      console.log(err);
    });
  }

  onAddCompany(){
    const dialogRef = this.dialog.open(AddProductionCompanyComponent, {
      width: '400px'
    })

    dialogRef.afterClosed().subscribe(m => {
      this.getProductionCompanies();
    });
  }
}
