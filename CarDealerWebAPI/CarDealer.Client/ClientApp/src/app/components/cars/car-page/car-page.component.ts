import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/services/car.service';
import { MatCarouselSlide, MatCarouselSlideComponent } from '@ngbmodule/material-carousel';
import { UserService } from '../../../services/user.service';
import { UserDTO } from '../../../DTOs/UserDTO';

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
  private _userService:UserService;
  private _userDTO?:UserDTO;

  constructor(
    router:Router,
    activatedRouter:ActivatedRoute,
    carService:CarService,
    userService:UserService
  ) 
  { 
    this._router = router;
    this._activatedRoute = activatedRouter;
    this._carService = carService;
    this._userService = userService;
  }

  ngOnInit(): void 
  {
    this._activatedRoute.params.subscribe(params =>
      {
        this._carService.getCar(params['id'])
        .subscribe(res => 
          {
            this._car = res;

            this._userService.getUser(this._car.userId)
            .subscribe(res => 
              {
                this._userDTO = res;
              })
          })
      })
  }

  public get getCar()
  {
    return this._car;
  }

  public get getUser():UserDTO|undefined
  {
    return this._userDTO;
  }

 

}
