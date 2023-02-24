import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductionCountryComponent } from './add-production-country.component';

describe('AddProductionCountryComponent', () => {
  let component: AddProductionCountryComponent;
  let fixture: ComponentFixture<AddProductionCountryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProductionCountryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductionCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
