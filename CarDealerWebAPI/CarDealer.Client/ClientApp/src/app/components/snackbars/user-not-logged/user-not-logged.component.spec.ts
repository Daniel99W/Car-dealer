import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserNotLoggedComponent } from './user-not-logged.component';

describe('UserNotLoggedComponent', () => {
  let component: UserNotLoggedComponent;
  let fixture: ComponentFixture<UserNotLoggedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserNotLoggedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserNotLoggedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
