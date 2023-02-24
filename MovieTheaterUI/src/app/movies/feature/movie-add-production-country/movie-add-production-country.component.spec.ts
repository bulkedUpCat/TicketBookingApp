import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddProductionCountryComponent } from './movie-add-production-country.component';

describe('MovieAddProductionCountryComponent', () => {
  let component: MovieAddProductionCountryComponent;
  let fixture: ComponentFixture<MovieAddProductionCountryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddProductionCountryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddProductionCountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
