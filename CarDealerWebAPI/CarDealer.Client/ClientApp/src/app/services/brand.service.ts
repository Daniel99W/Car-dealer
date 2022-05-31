import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
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
    return this._httpClient.get<Array<Brand>>(UrlConstants.apiUrl+'/Brand/GetBrands');
  }

  public addBrand(brand:Brand):Observable<any>
  {
    let body = 
    {
      Name:brand.name,
      Description:brand.description
    }

    return this._httpClient.post<any>(UrlConstants.apiUrl+'/Brand/AddBrand',body);
  }

  public editBrand(brand:Brand):Observable<Brand>
  {
    return this._httpClient.post<Brand>(UrlConstants.apiUrl+'/Brand/UpdateBrand',brand);
  }
  public deleteBrand(id:string):Observable<any>
  {
    return this._httpClient.delete(UrlConstants.apiUrl+'/Brand/DeleteBrand/'+id);
  }

  public getBrand(id:string):Observable<Brand>
  {
    return this._httpClient.get<Brand>(UrlConstants.apiUrl+'/Brand/GetBrand/'+id);
  }
}
