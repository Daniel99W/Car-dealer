import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { SecurityService } from './security.service';
import { TokenService } from './token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate
{
  private securityService:SecurityService;
  private router:Router;
  private cookieService:CookieService;
  private tokenService:TokenService;

  constructor(
    securityService:SecurityService,
    router:Router,
    cookieService:CookieService,
    tokenService:TokenService
  ) 
  { 
    this.securityService = securityService;
    this.router = router;
    this.cookieService = cookieService;
    this.tokenService = tokenService;
  }
  canActivate(activatedRoute:ActivatedRouteSnapshot):boolean
  {
    
    let role:string|undefined = this.tokenService.getTokenObject()?.role;

    if(!(this.securityService.isAuthenticated && activatedRoute.data.role == role))
    {
      this.router.navigate(['login']);

      return false;
    }
    return true;
  }
  
}
