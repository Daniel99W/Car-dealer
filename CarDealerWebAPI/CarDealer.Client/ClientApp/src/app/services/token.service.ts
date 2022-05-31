import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { Token } from '../Models/Token';

@Injectable({
  providedIn: 'root'
})
export class TokenService 
{
  private jwtHelper:JwtHelperService;
  private cookieService:CookieService;

  constructor(
    cookieService:CookieService,
    jwtHelper:JwtHelperService
    ) 
  {
    this.cookieService = cookieService;
    this.jwtHelper = jwtHelper;
  }
  public getToken():string | null
  {
    return this.cookieService.get('accessToken');
  }


  public getTokenObject():Token|null
  {
    let tokenCoded:string = this.cookieService.get("accessToken");
    if(tokenCoded.length > 0)
    {
      let userId:string = this.jwtHelper.decodeToken(tokenCoded)["UserId"];
      let role:string = this.jwtHelper.decodeToken(tokenCoded)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

      let token:Token = new Token(userId,role);

      return token;
    }
    return null;
  }
}
