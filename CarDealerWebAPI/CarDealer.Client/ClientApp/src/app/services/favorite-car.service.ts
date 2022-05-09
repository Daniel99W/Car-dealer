import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
import { Car } from '../Models/Car';

@Injectable({
  providedIn: 'root'
})
export class FavoriteCarService 
{

  private _httpClient:HttpClient;

  constructor(http:HttpClient) 
  { 
    this._httpClient = http;
  }

  public getFavoriteCarsByUserId(userId:string):Observable<Array<Car>>
  {
    return this._httpClient.get<Array<Car>>(UrlConstants.apiUrl+`/UserCar/GetUserFavoriteCarsByUserId${userId}`);
  }

  public addToFavorite(carId:string,userId:string):Observable<any>
  {
    let body = 
    {
      CarId:carId,
      UserId:userId
    }

    return this._httpClient.post(UrlConstants.apiUrl+'/UserCar/AddCarUserFavoriteList',body);
  }
}
