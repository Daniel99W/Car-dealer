import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/Models/Car';
import { CarService } from 'src/app/services/car.service';
import { MatCarouselSlide, MatCarouselSlideComponent } from '@ngbmodule/material-carousel';
import { UserService } from '../../../services/user.service';
import { UserDTO } from '../../../DTOs/UserDTO';
import { SecurityService } from 'src/app/services/security.service';
import { TokenService } from 'src/app/services/token.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserNotLoggedComponent } from '../../snackbars/user-not-logged/user-not-logged.component';

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
  private _securityService:SecurityService;
  private _tokenService:TokenService;
  private _snackBar:MatSnackBar;

  constructor(
    router:Router,
    activatedRouter:ActivatedRoute,
    carService:CarService,
    userService:UserService,
    securityService:SecurityService,
    tokenService:TokenService,
    snackBar:MatSnackBar
  ) 
  { 
    this._router = router;
    this._activatedRoute = activatedRouter;
    this._carService = carService;
    this._userService = userService;
    this._securityService = securityService;
    this._tokenService = tokenService;
    this._snackBar = snackBar;
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

  public sendMessage()
  {
    if(this._securityService.isAuthenticated)
    {
      this._router.navigate(['/sendMessage',this._userDTO?.id]);
    }
    else 
    {
      this._snackBar.openFromComponent(UserNotLoggedComponent,
        {
          data:'You are not logged in',
            duration:3000,
            verticalPosition:'top',
            horizontalPosition:'center',
            panelClass:['userNotLogged']
        })
    }
  }

 

}
