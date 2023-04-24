import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LoginDTO } from 'src/app/DTOs/LoginDTO';
import { SecurityService } from 'src/app/services/security.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit
{
  private _loginDTO!:LoginDTO;
  private _securityService:SecurityService;
  private cookieService:CookieService;
  private router:Router;

  constructor(
    securityService:SecurityService,
    cookieService:CookieService,
    router:Router
    ) 
  {
    this._loginDTO = new LoginDTO();
    this._securityService = securityService;
    this.cookieService = cookieService;
    this.router = router;
  }

  ngOnInit(): void 
  {

  }

  public get loginDTO():LoginDTO
  {
    return this._loginDTO;
  }

  public Login()
  {
    
    this._securityService.login(this._loginDTO).subscribe(res =>
      {
        if(res.value != null)
            {
              let token:string = res.value;
              this.cookieService.set('accessToken',token);
              this.router.navigate(['carFeed']);
              window.location.reload();
            }
      });
  }
}
