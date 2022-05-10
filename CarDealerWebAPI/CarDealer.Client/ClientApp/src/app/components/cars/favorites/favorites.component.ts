import { Component, OnInit } from '@angular/core';
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

  constructor(
    favoriteCarService:FavoriteCarService,
    tokenService:TokenService
    ) 
  { 
    this.favoriteCarService = favoriteCarService;
    this.tokenService = tokenService;
    this.favoriteCars = new Array<Car>();
  }

  ngOnInit(): void 
  {
    let userId = this.tokenService.getTokenObject().userId;

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
      this.tokenService.getTokenObject().userId,
      carId
    ).subscribe(res =>
      {
        console.log(res);
      })
  }

 

 
}
