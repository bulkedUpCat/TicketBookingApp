import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieLanguagesComponent } from './movie-languages.component';

describe('MovieLanguagesComponent', () => {
  let component: MovieLanguagesComponent;
  let fixture: ComponentFixture<MovieLanguagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieLanguagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieLanguagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
