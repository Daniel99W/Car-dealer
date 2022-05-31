import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Car } from '../../../Models/Car';
import { FavoriteCarService } from '../../../services/favorite-car.service';
import { TokenService } from '../../../services/token.service';

@Component({
  selector: 'app-favorites',
  templateUrl: './favorites.component.html',
  styleUrls: ['./favorites.component.css']
})
export class FavoritesComponent implements OnInit 
{
  private favoriteCarService:FavoriteCarService;
  private favoriteCars:Array<Car>;
  private tokenService:TokenService;
  private router:Router;

  constructor(
    favoriteCarService:FavoriteCarService,
    tokenService:TokenService,
    router:Router
    ) 
  { 
    this.favoriteCarService = favoriteCarService;
    this.tokenService = tokenService;
    this.favoriteCars = new Array<Car>();
    this.router = router;
  }

  ngOnInit(): void 
  {
    let userId = this.tokenService.getTokenObject()!.userId;

    this.favoriteCarService.getFavoriteCarsByUserId(userId)
    .subscribe(res =>
      {
        console.log(userId);
        console.log(res);
        this.favoriteCars = res;
      })
  }

  public get getFavoriteCars():Array<Car>
  {
    return this.favoriteCars;
  }


  public removeCar(carId:string)
  {
    this.favoriteCarService.removeCarFromUserFavoriteList(
      this.tokenService.getTokenObject()!.userId,
      carId
    ).subscribe(res =>
      {
        let index = this.favoriteCars.indexOf(this.favoriteCars!.find(value => value.id == carId)!);
        this.favoriteCars!.splice(index,1);
      })
  }

  public getCar(carId:string)
  {
    this.router.navigate(['car',carId]);
  }

 
}
