import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScrollBarUiComponent } from './scroll-bar-ui.component';

describe('ScrollBarUiComponent', () => {
  let component: ScrollBarUiComponent;
  let fixture: ComponentFixture<ScrollBarUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScrollBarUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScrollBarUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
