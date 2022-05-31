import { Component, OnInit } from '@angular/core';
import { UserDTO } from '../../../DTOs/UserDTO';
import { TokenService } from '../../../services/token.service';
import { UserService } from '../../../services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit 
{

  private userService:UserService;
  private tokenService:TokenService;
  private userDTO!:UserDTO;

  constructor(
    userService:UserService,
    tokenService:TokenService
    ) 
  {   
    this.userService = userService;
    this.tokenService = tokenService;
  }


  public get getUser():UserDTO
  {
    return this.userDTO;
  }

  ngOnInit(): void 
  {
    this.userService.getUser(this.tokenService.getTokenObject()!.userId.toString())
    .subscribe(res => 
      {
        this.userDTO = res;
        console.log(res);
        console.log(this.userDTO);
      })
  }

  public editUser()
  {
    this.userService.editUser(this.userDTO)
    .subscribe(res => 
      {
        console.log(res);
      })
  }

}
