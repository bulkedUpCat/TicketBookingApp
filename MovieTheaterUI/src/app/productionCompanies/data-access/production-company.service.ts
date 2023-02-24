import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICreateProductionCompany } from 'src/app/shared/models/productionCompany';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductionCompanyService {

  constructor(private http: HttpClient) { }

  getProductionCompanies(): Observable<any>{
    return this.http.get(`${environment.apiUrl}/productionCompanies`);
  }

  createProductionCompany(model: ICreateProductionCompany){
    return this.http.post(`${environment.apiUrl}/productionCompanies`, model);
  }
}
