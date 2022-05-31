import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { forkJoin, from } from 'rxjs';
import { SecurityService } from 'src/app/services/security.service';
import { TokenService } from 'src/app/services/token.service';
import { UserDTO } from '../../DTOs/UserDTO';
import { CarService } from '../../services/car.service';
import { FavoriteCarService } from '../../services/favorite-car.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit 
{
  private securityService:SecurityService;
  private router:Router;
  private tokenService:TokenService;
  private cookieService:CookieService;
  private userService:UserService;
  private userDTO?:UserDTO;
  private favoriteCarService:FavoriteCarService;
  private carsNumberInFavoriteList!:number;
  private carService:CarService;
  private carsNumber!:number;

  constructor(
    securityService:SecurityService,
    router:Router,
    tokenService:TokenService,
    cookieService:CookieService,
    userService:UserService,
    favoriteCarService:FavoriteCarService,
    carService:CarService
  ) 
  {
    this.securityService = securityService;
    this.router = router;
    this.tokenService = tokenService;
    this.cookieService = cookieService;
    this.userService = userService;
    this.favoriteCarService = favoriteCarService;
    this.carService = carService;
  }

  public get getUser():UserDTO|undefined
  {
    return this.userDTO;
  }

  ngOnInit(): void 
  {
    if(this.securityService.isAuthenticated)
    {

      let userId = this.tokenService.getTokenObject()!.userId.toString();

      let carsNumberInFavoriteList = from(this.favoriteCarService.
        getCarsNumberInFavoriteListByUserId(userId))
      let user = from(this.userService.getUser(userId));
      let carsNumber = from(this.carService.getCarsNumber(userId))

      forkJoin([carsNumberInFavoriteList,user,carsNumber])
      .subscribe(res => 
        {
          this.carsNumberInFavoriteList = res[0];
          this.userDTO = res[1];
          this.carsNumber = res[2];
        })
    }
  }
  public isAuthorized(role:string)
  {
    return this.tokenService.getTokenObject()!.role == role ? true:false;
  }

  public isAuthenticated():boolean
  {
    return this.securityService.isAuthenticated;
  }

  public get getCarsNumberInFavoriteList():number
  {
    return this.carsNumberInFavoriteList;
  }

  public get getCarsNumber():number 
  {
    return this.carsNumber;
  }

  public getUserId():string
  {
    return this.tokenService.getTokenObject()!.userId;
  }

  public logout()
  {
    this.cookieService.delete('accessToken');
  }

}
