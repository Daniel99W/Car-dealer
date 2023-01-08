import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { User } from 'oidc-client';
import { MessageDTO } from 'src/app/DTOs/MessageDTO';
import { UserDTO } from 'src/app/DTOs/UserDTO';
import { MessagesService } from 'src/app/services/messages.service';
import { SecurityService } from 'src/app/services/security.service';
import { TokenService } from 'src/app/services/token.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.css']
})
export class SendMessageComponent implements OnInit 
{
  private messageService:MessagesService;
  private userService:UserService;
  private form:FormGroup;
  private activatedRoute:ActivatedRoute;
  private receiverUser?:UserDTO;
  private senderUser?:UserDTO;
  private securityService:SecurityService;
  private tokenService:TokenService;
  

  constructor(
    messageService:MessagesService,
    activatedRoute:ActivatedRoute,
    securityService:SecurityService,
    tokenService:TokenService,
    userService:UserService
    ) 
  {
    this.messageService = messageService;
    this.activatedRoute = activatedRoute;
    this.securityService = securityService;
    this.tokenService = tokenService;
    this.userService = userService;
    this.form = new FormGroup({
      subject:new FormControl(),
      content:new FormControl(),
    }
    )
  }

  ngOnInit(): void 
  {
    this.activatedRoute.params.subscribe(params =>
      {
        this.userService.getUser(params['userId'])
        .subscribe(res => 
          {
            this.receiverUser = res;
          })
      })

      if(this.securityService.isAuthenticated)
      {
        let userId = this.tokenService.getTokenObject()!.userId.toString();
  
        this.userService.getUser(userId).subscribe(res =>
          {
            this.senderUser = res;
          })
      }

  }


  public get getReceiverUser():UserDTO
  {
    return this.receiverUser!;
  }

  public get getSenderUser():UserDTO
  {
    return this.senderUser!;
  }

  public get messageForm():FormGroup 
  {
    return this.form;
  }

  public set messageForm(value:FormGroup)
  {
    this.form = value;
  }

  public sendMessage()
  {
    let messageDTO = new MessageDTO();
    messageDTO.content = this.form.get('content')?.value;
    messageDTO.subject = this.form.get('subject')?.value;
    messageDTO.receiverId = this.receiverUser?.id as string;
    messageDTO.senderId = this.senderUser?.id as string;


    this.messageService.sendMessage(messageDTO)
    .subscribe(res => 
      {
        console.log(res);
      })
  }

}
