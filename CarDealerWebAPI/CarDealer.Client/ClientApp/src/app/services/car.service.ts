import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarUrls } from '../Constants/CarUrls';
import { CarParametersQueryDTO } from '../DTOs/CarParametersQueryDTO';
import { PaginatedDTO } from '../DTOs/PaginatedDTO';

import { Car } from '../Models/Car';

@Injectable({
  providedIn: 'root'
})
export class CarService 
{
  private _httpClient:HttpClient;

  constructor(http:HttpClient) 
  { 
    this._httpClient = http;
  }

  public getCars(carParametersQueryDTO:CarParametersQueryDTO):Observable<PaginatedDTO<Car>>
  {
    let body = 
    {
      Page:carParametersQueryDTO.page,
      CarsPerPage:carParametersQueryDTO.carsPerPage,
      Brand:carParametersQueryDTO.brand,
      CarType:carParametersQueryDTO.carType,
      Title:carParametersQueryDTO.title,
      ProducionYear:carParametersQueryDTO.title,
      MinPrice:carParametersQueryDTO.minPrice,
      MaxPrice:carParametersQueryDTO.maxPrice,
      OrderBy:carParametersQueryDTO.orderBy
    }
    return this._httpClient.post<PaginatedDTO<Car>>(CarUrls.getCarsUrl,body);
  }

}
