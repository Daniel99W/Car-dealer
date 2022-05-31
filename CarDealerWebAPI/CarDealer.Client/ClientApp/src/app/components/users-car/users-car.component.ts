import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarParametersQueryDTO } from '../../DTOs/CarParametersQueryDTO';
import { Car } from '../../Models/Car';
import { CarService } from '../../services/car.service';

@Component({
  selector: 'app-users-car',
  templateUrl: './users-car.component.html',
  styleUrls: ['./users-car.component.css']
})
export class UsersCarComponent implements OnInit 
{

  private cars?:Array<Car>;
  private carService:CarService;
  private activatedRoute:ActivatedRoute;
  private router:Router;

  constructor(
    carService:CarService,
    activatedRoute:ActivatedRoute,
    router:Router
    ) 
  {
    this.carService = carService;
    this.activatedRoute = activatedRoute;
    this.router = router;
  }

  public get getCars():Array<Car>|undefined
  {
    return this.cars;
  }

  ngOnInit(): void 
  {
    this.activatedRoute.params.subscribe(params =>
      {
        this.carService.getCarsByUserId(params['userId'])
        .subscribe(res =>
          {
            this.cars = res;
          })
      })
  }

  public getCar(carId:string)
  {
    this.router.navigate(['car',carId])
  }

  public editCar(carId:string)
  {
    this.router.navigate(['editCar',carId]);
  }

  public deleteCar(carId:string)
  {
    this.carService.deleteCar(carId)
    .subscribe(res =>
      {
        let index = this.cars!.indexOf(this.cars!.find(value => value.id == carId)!);
        this.cars!.splice(index,1);
      })
  }

}
