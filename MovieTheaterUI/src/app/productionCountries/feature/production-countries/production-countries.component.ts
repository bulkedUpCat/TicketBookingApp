import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IProductionCountryModel } from 'src/app/shared/models/productionCountry';
import { ProductionCountryService } from '../../data-access/production-country.service';
import { AddProductionCountryComponent } from '../add-production-country/add-production-country.component';

@Component({
  selector: 'app-production-countries',
  templateUrl: './production-countries.component.html',
  styleUrls: ['./production-countries.component.scss']
})
export class ProductionCountriesComponent implements OnInit {
  countries: IProductionCountryModel[];
  constructor(private productionCountryService: ProductionCountryService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getProductionCountries();
  }

  getProductionCountries(){
    this.productionCountryService.getProductionCountries().subscribe(c => {
      this.countries = c;
      console.log(c);
    }, err => console.log(err));
  }

  onAddCountry(){
    const dialogRef = this.dialog.open(AddProductionCountryComponent, {
      width: '400px'
    })

    dialogRef.afterClosed().subscribe(m => {
      this.getProductionCountries();
    });
  }
}
