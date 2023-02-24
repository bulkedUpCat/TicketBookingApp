import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendReservationComponent } from './send-reservation.component';

describe('SendReservationComponent', () => {
  let component: SendReservationComponent;
  let fixture: ComponentFixture<SendReservationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendReservationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SendReservationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
