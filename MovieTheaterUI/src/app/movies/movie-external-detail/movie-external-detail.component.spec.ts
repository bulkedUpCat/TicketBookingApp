import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovieExternalDetailComponent } from './movie-external-detail.component';

describe('MovieExternalDetailComponent', () => {
  let component: MovieExternalDetailComponent;
  let fixture: ComponentFixture<MovieExternalDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovieExternalDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovieExternalDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
