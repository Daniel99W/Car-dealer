import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'oidc-client';
import { CreateUserDTO } from '../../DTOs/CreateUserDTO';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit 
{
  private _userService:UserService;
  private _userForm:FormGroup;
  private _router:Router;


  constructor(
    userService:UserService,
    router:Router
    ) 
  { 
    this._userService = userService;
    this._userForm = new FormGroup(
      {
        name:new FormControl(),
        secondName:new FormControl(),
        email:new FormControl(),
        password:new FormControl()
      }
    )
    this._router = router;
  }

  ngOnInit(): void 
  {

  }

  public get userForm():FormGroup
  {
    return this._userForm;
  }

  

  public signUp()
  {
    console.log(this._userForm.get('email')!.value)
    this._userService.signUpUser(new CreateUserDTO(
      this._userForm.get('email')!.value,
      this._userForm.get('name')!.value,
      this._userForm.get('secondName')!.value,
      this._userForm.get('password')!.value
      )).subscribe(res => 
        {
          this._router.navigate(['login']);
        })
  }

}
