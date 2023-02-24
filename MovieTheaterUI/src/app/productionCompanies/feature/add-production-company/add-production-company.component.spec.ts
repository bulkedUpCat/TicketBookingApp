import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductionCompanyComponent } from './add-production-company.component';

describe('AddProductionCompanyComponent', () => {
  let component: AddProductionCompanyComponent;
  let fixture: ComponentFixture<AddProductionCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddProductionCompanyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductionCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
