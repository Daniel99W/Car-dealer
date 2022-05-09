import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from './services/security.service';
import { TokenService } from './services/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls:['./app.component.css']
})
export class AppComponent 
{
  private router:Router;
  private loginService:SecurityService;
  private tokenService:TokenService;

  constructor(
    router:Router,
    loginService:SecurityService,
    tokenService:TokenService
  )
  {
    this.router = router;
    this.loginService = loginService;
    this.tokenService = tokenService;
  }

  
  
}
