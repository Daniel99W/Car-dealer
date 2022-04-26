import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginatedResultDTO } from '../DTOs/PaginatedResultDTO';

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

  public getCars():Observable<PaginatedResultDTO<Car>>
  {
    return this._httpClient.get()
  }

}
