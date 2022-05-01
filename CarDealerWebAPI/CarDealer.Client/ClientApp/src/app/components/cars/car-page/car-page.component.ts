import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-page',
  templateUrl: './car-page.component.html',
  styleUrls: ['./car-page.component.css']
})
export class CarPageComponent implements OnInit 
{
  private _activatedRoute!:ActivatedRoute;
  private _router!:Router;
  private _carService!:CarService;
  private _car?:Car;

  constructor(
    router:Router,
    activatedRouter:ActivatedRoute,
    carService:CarService
  ) 
  { 
    this._router = router;
    this._activatedRoute = activatedRouter;
    this._carService = carService;
  }

  ngOnInit(): void 
  {
    this._activatedRoute.params.subscribe(params =>
      {
        this._carService.getCar(params['id'])
        .subscribe(res => 
          {
            this._car = res;
            console.log(res);
          })
      })
  }

 

}
