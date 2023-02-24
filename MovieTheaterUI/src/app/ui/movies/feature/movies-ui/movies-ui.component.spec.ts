import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesUiComponent } from './movies-ui.component';

describe('MoviesUiComponent', () => {
  let component: MoviesUiComponent;
  let fixture: ComponentFixture<MoviesUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoviesUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviesUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
