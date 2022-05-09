import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FuelTypeUrls } from '../Constants/FuelTypeUrls';
import { FuelType } from '../Models/FuelType';

@Injectable({
  providedIn: 'root'
})
export class FuelTypeService 
{
  private httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  {
    this.httpClient = httpClient;
  }

  public getFuelTypes():Observable<Array<FuelType>>
  {
    return this.httpClient.get<Array<FuelType>>(FuelTypeUrls.getFuelTypes);
  }


}
