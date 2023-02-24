import { TestBed } from '@angular/core/testing';

import { MovieLanguageService } from './movie-language.service';

describe('MovieLanguageService', () => {
  let service: MovieLanguageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MovieLanguageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
