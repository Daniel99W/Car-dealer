import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarTypesListComponent } from './car-types-list.component';

describe('CarTypesListComponent', () => {
  let component: CarTypesListComponent;
  let fixture: ComponentFixture<CarTypesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarTypesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarTypesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
