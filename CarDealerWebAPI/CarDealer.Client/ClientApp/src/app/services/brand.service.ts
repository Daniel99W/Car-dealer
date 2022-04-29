import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BrandUrls } from '../Constants/BrandUrls';
import { Brand } from '../Models/Brand';

@Injectable({
  providedIn: 'root'
})
export class BrandService 
{
  private _httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  { 
    this._httpClient = httpClient;
  }

  public getBrands():Observable<Array<Brand>>
  {
    return this._httpClient.get<Array<Brand>>(BrandUrls.getBrands);
  }
}
