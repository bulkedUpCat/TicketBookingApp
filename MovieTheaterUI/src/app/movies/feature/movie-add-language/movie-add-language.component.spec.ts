import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddLanguageComponent } from './movie-add-language.component';

describe('MovieAddLanguageComponent', () => {
  let component: MovieAddLanguageComponent;
  let fixture: ComponentFixture<MovieAddLanguageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddLanguageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddLanguageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
