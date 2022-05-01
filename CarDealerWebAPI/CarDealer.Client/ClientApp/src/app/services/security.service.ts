import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { SecurityUrls } from '../Constants/SecurityUrls';
import { CreateUserDTO } from '../DTOs/CreateUserDTO';
import { LoginDTO } from '../DTOs/LoginDTO';

@Injectable({
  providedIn: 'root'
})
export class SecurityService 
{
  private httpClient;
  private cookieService;

  constructor(
    httpClient:HttpClient,
    cookieService:CookieService
    ) 
  { 
    this.httpClient = httpClient;
    this.cookieService = cookieService;
  }

  public login(loginDTO:LoginDTO):Observable<any>
  {
    let body = 
    {
      Email:loginDTO.Email,
      Password:loginDTO.Password
    }
    return this.httpClient.post<any>(SecurityUrls.login,body);
  }

  public signUp(createUserDTO:CreateUserDTO)
  {

    return this.httpClient.post<any>(SecurityUrls.signUp,createUserDTO);
  }

  public set isAuthenticated(value:boolean)
  {
    this.isAuthenticated = value;
  }
  public get isAuthenticated():boolean
  {
    if(this.cookieService.get('accessToken'))
      return this.isAuthenticated;

    return this.isAuthenticated;
  }
}
