import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCountriesComponent } from './production-countries.component';

describe('ProductionCountriesComponent', () => {
  let component: ProductionCountriesComponent;
  let fixture: ComponentFixture<ProductionCountriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCountriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionCountriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
