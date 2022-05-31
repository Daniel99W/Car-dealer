import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
import { CreateCarDTO } from '../DTOs/CreateCarDTO';
import { CreateUserDTO } from '../DTOs/CreateUserDTO';
import { UserDTO } from '../DTOs/UserDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService 
{
  private _httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  {
    this._httpClient = httpClient;
  }


  public getUser(id:string):Observable<UserDTO>
  {
    return this._httpClient.get<UserDTO>(UrlConstants.apiUrl+'/Users/GetUserById/'+id);
  }

  public editUser(userDTO:UserDTO):Observable<any>
  {
    let body = 
    {
      Email:userDTO.email,
      SecondName:userDTO.secondName,
      Name:userDTO.name
    }
    return this._httpClient.post<any>(UrlConstants.apiUrl+'/Users/UpdateUser',body);
  }

  public signUpUser(createUserDTO:CreateUserDTO):Observable<any>
  {
    let body = 
    {
      Email:createUserDTO.Email,
      Name:createUserDTO.Name,
      Password:createUserDTO.Password,
      SecondName:createUserDTO.SecondName
    }

    return this._httpClient.post<any>(UrlConstants.apiUrl+'/Users/SignUp',body);
  }
}
