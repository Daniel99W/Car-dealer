import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
import { CreateUserDTO } from '../DTOs/CreateUserDTO';
import { LoginDTO } from '../DTOs/LoginDTO';

@Injectable({
  providedIn: 'root'
})
export class SecurityService 
{
  private _httpClient;
  private _cookieService;
  private _isAuthenticated:boolean;

  constructor(
    httpClient:HttpClient,
    cookieService:CookieService
    ) 
  { 
    this._httpClient = httpClient;
    this._cookieService = cookieService;
    this._isAuthenticated = false;
  }

  public login(loginDTO:LoginDTO):Observable<any>
  {
    let body = 
    {
      Email:loginDTO.Email,
      Password:loginDTO.Password
    }
    return this._httpClient.post(UrlConstants.apiUrl+'/Users/Login',body);
  }

  public signUp(createUserDTO:CreateUserDTO):Observable<any>
  {
    return this._httpClient.post(UrlConstants.apiUrl+'/Users/SignUp',createUserDTO);
  }

  public set isAuthenticated(value:boolean)
  {
    this._isAuthenticated = value;
  }
  public get isAuthenticated():boolean
  {
    if(this._cookieService.get('accessToken'))
      return this._isAuthenticated = true;

    return this._isAuthenticated;
  }
}
