import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersCarComponent } from './users-car.component';

describe('UsersCarComponent', () => {
  let component: UsersCarComponent;
  let fixture: ComponentFixture<UsersCarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersCarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersCarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
