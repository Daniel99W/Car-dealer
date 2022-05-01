import { Component, OnInit } from '@angular/core';
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

  constructor(
    securityService:SecurityService,
    cookieService:CookieService
    ) 
  {
    this._loginDTO = new LoginDTO();
    this._securityService = securityService;
    this.cookieService = cookieService;
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
              console.log(res);
              this.cookieService.set('accessToken',token,res.expires);
            }
      });
  }



}
