import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarTypeUrls } from '../Constants/CarTypeUrls';
import { CarType } from '../Models/CarType';

@Injectable({
  providedIn: 'root'
})
export class CarTypeService 
{
  private _httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  {
    this._httpClient = httpClient;
  }

  public getCarTypes():Observable<Array<CarType>>
  {

    return this._httpClient.get<Array<CarType>>(CarTypeUrls.getCarTypes);
  }
}
