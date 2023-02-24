import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateProductionCountry } from 'src/app/shared/models/productionCountry';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductionCountryService {

  constructor(private http: HttpClient) { }

  getProductionCountries(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/productionCountries`);
  }

  createProductionCountry(model: ICreateProductionCountry){
    return this.http.post(`${environment.apiUrl}/productionCountries`, model);
  }
}
