import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Message } from 'src/app/Models/Message';
import { MessagesService } from 'src/app/services/messages.service';
import { SecurityService } from 'src/app/services/security.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit 
{

  public messages:Array<Message>;
  private messageService:MessagesService;
  private tokenService:TokenService;
  private securityService:SecurityService;
  private router:Router;

  constructor(
    messageService:MessagesService,
    tokenService:TokenService,
    securityService:SecurityService,
    router:Router
    ) 
  { 
    this.messages = new Array<Message>();
    this.messageService = messageService;
    this.tokenService = tokenService;
    this.securityService = securityService;
    this.router = router
  }

  ngOnInit(): void 
  {
    if(this.securityService.isAuthenticated)
    {
      let userId = this.tokenService.getTokenObject()!.userId.toString();

      this.messageService.getMessages(userId).subscribe(res => 
        {
          this.messages = res;
          console.log(res);
        })
    }
   
  }

  public get getMessages():Array<Message>
  {
    return this.messages;
  }

  public deleteMessage(id:string)
  { 
    this.messageService.deleteMessage(id)
    .subscribe(res =>
      {
        console.log(res);
        this.ngOnInit();
      })
  }

  public reply(senderId:string)
  {
    console.log(senderId);
    this.router.navigate(['sendMessage',senderId]);
  }


}
