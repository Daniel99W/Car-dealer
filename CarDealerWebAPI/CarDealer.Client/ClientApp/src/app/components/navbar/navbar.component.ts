import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SecurityService } from 'src/app/services/security.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit 
{
  private securityService:SecurityService;
  private router:Router;
  private tokenService:TokenService;

  constructor(
    securityService:SecurityService,
    router:Router,
    tokenService:TokenService
  ) 
  {
    this.securityService = securityService;
    this.router = router;
    this.tokenService = tokenService;
  }

  ngOnInit(): void 
  {
  }

  public isAuthorized(role:string)
  {
    return this.tokenService.getTokenObject().role == role ? true:false;
  }

}
