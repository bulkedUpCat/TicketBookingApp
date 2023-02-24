import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPageUiComponent } from './user-page-ui.component';

describe('UserPageUiComponent', () => {
  let component: UserPageUiComponent;
  let fixture: ComponentFixture<UserPageUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPageUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserPageUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
