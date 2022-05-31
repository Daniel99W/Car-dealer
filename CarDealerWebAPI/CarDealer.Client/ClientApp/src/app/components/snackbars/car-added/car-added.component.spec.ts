import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarAddedComponent } from './car-added.component';

describe('CarAddedComponent', () => {
  let component: CarAddedComponent;
  let fixture: ComponentFixture<CarAddedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarAddedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarAddedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
