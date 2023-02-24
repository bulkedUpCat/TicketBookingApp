import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompaniesComponent } from './production-companies.component';

describe('ProductionCompaniesComponent', () => {
  let component: ProductionCompaniesComponent;
  let fixture: ComponentFixture<ProductionCompaniesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompaniesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionCompaniesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
