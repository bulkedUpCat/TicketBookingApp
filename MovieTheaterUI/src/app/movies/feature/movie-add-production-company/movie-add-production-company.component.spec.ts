import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddProductionCompanyComponent } from './movie-add-production-company.component';

describe('MovieAddProductionCompanyComponent', () => {
  let component: MovieAddProductionCompanyComponent;
  let fixture: ComponentFixture<MovieAddProductionCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddProductionCompanyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddProductionCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
