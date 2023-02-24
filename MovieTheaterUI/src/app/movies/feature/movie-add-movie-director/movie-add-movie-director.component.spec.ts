import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddMovieDirectorComponent } from './movie-add-movie-director.component';

describe('MovieAddMovieDirectorComponent', () => {
  let component: MovieAddMovieDirectorComponent;
  let fixture: ComponentFixture<MovieAddMovieDirectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddMovieDirectorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddMovieDirectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
