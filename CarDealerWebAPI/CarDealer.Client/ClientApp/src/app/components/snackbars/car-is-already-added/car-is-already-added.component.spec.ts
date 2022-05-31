import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarIsAlreadyAddedComponent } from './car-is-already-added.component';

describe('CarIsAlreadyAddedComponent', () => {
  let component: CarIsAlreadyAddedComponent;
  let fixture: ComponentFixture<CarIsAlreadyAddedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarIsAlreadyAddedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarIsAlreadyAddedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
