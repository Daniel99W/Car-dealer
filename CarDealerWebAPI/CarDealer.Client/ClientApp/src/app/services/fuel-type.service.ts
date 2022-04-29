import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FuelType } from '../Models/FuelType';

@Injectable({
  providedIn: 'root'
})
export class FuelTypeService 
{
  private _httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  {
    this._httpClient = httpClient;
  }


}
