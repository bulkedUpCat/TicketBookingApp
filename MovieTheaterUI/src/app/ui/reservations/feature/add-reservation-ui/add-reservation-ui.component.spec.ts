import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddReservationUiComponent } from './add-reservation-ui.component';

describe('AddReservationUiComponent', () => {
  let component: AddReservationUiComponent;
  let fixture: ComponentFixture<AddReservationUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddReservationUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddReservationUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
