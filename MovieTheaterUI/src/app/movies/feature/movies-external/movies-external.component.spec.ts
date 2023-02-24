import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoviesExternalComponent } from './movies-external.component';

describe('MoviesExternalComponent', () => {
  let component: MoviesExternalComponent;
  let fixture: ComponentFixture<MoviesExternalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MoviesExternalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MoviesExternalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
