import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScreeningUiComponent } from './screening-ui.component';

describe('ScreeningUiComponent', () => {
  let component: ScreeningUiComponent;
  let fixture: ComponentFixture<ScreeningUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScreeningUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScreeningUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
