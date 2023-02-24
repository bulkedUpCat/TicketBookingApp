import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMovieLanguageComponent } from './add-movie-language.component';

describe('AddMovieLanguageComponent', () => {
  let component: AddMovieLanguageComponent;
  let fixture: ComponentFixture<AddMovieLanguageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMovieLanguageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMovieLanguageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
