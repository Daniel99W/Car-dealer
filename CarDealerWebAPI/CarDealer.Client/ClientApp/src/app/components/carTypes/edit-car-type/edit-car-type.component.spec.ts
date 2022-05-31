import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCarTypeComponent } from './edit-car-type.component';

describe('EditCarTypeComponent', () => {
  let component: EditCarTypeComponent;
  let fixture: ComponentFixture<EditCarTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditCarTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCarTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
