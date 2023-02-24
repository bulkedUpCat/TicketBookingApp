import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddGenreComponent } from './movie-add-genre.component';

describe('MovieAddGenreComponent', () => {
  let component: MovieAddGenreComponent;
  let fixture: ComponentFixture<MovieAddGenreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddGenreComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
