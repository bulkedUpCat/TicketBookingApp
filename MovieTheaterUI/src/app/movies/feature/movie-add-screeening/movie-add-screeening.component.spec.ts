import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieAddScreeeningComponent } from './movie-add-screeening.component';

describe('MovieAddScreeeningComponent', () => {
  let component: MovieAddScreeeningComponent;
  let fixture: ComponentFixture<MovieAddScreeeningComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieAddScreeeningComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieAddScreeeningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
