import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCarTypeComponent } from './add-car-type.component';

describe('AddCarTypeComponent', () => {
  let component: AddCarTypeComponent;
  let fixture: ComponentFixture<AddCarTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCarTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCarTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
