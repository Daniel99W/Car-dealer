import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarFeedComponent } from './car-feed.component';

describe('CarFeedComponent', () => {
  let component: CarFeedComponent;
  let fixture: ComponentFixture<CarFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarFeedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
