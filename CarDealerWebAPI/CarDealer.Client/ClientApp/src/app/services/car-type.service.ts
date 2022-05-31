import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
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

    return this._httpClient.get<Array<CarType>>(UrlConstants.apiUrl+'/CarType/GetCarTypes');
  }

  public addCarType(carType:CarType):Observable<any>
  {
    let body = 
    {
      Name:carType.name
    }

    return this._httpClient.post<any>(UrlConstants.apiUrl+'/CarType/AddCarType',body);
  }

  public deleteCarType(id:string)
  {
    return this._httpClient.delete<any>(UrlConstants.apiUrl+'/CarTypes/DeleteCarType/'+id);
  }

  public editCarType(carType:CarType)
  {

    return this._httpClient.post<any>(UrlConstants.apiUrl+'/CarTypes/UpdateCarType',carType);
  }

  public getCarType(id:string):Observable<CarType>
  {
    return this._httpClient.get<CarType>(UrlConstants.apiUrl+'/CarType/GetCarType/'+id);
  }
}
