import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from '../../../Models/Car';
import { CarService } from '../../../services/car.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit 
{

  private carService:CarService;
  private activatedRouter:ActivatedRoute;
  private car?:Car;

  constructor(
    carService:CarService,
    activatedRouter:ActivatedRoute
    ) 
  { 
    this.carService = carService;
    this.activatedRouter = activatedRouter;
  }

  ngOnInit(): void 
  {
    this.activatedRouter.params.subscribe(params =>
      {
        this.carService.getCar(params['id'])
        .subscribe(res => 
          {
            this.car = res;
          })
      })
  }


  public editCar(car:Car)
  {
     this.carService.editCar(car)
     .subscribe(res => 
      {
        console.log(res);
      })
  }

}
