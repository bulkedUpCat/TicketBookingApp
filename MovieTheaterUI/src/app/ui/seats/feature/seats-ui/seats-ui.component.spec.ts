import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatsUiComponent } from './seats-ui.component';

describe('SeatsUiComponent', () => {
  let component: SeatsUiComponent;
  let fixture: ComponentFixture<SeatsUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatsUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatsUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
