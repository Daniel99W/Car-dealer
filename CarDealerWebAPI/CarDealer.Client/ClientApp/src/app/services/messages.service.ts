import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
import { MessageDTO } from '../DTOs/MessageDTO';
import { Message } from '../Models/Message';


@Injectable({
  providedIn: 'root'
})
export class MessagesService 
{
  private _httpClient:HttpClient;

  constructor(httpClient:HttpClient) 
  { 
    this._httpClient = httpClient;
  }

  public getMessage(id:string):Observable<Message>
  {
    return this._httpClient.get<Message>(UrlConstants.apiUrl+'/Messages/GetMessage/'+id);
  }

  public sendMessage(messageDTO:MessageDTO)
  {
    let body = 
    {
      ReceiverId:messageDTO.receiverId,
      SenderId:messageDTO.senderId,
      Content:messageDTO.content,
      Subject:messageDTO.subject
    }

    return this._httpClient.post(UrlConstants.apiUrl+'/Messages/SendMessage',body);
  }

  public getMessages(receiverId:string):Observable<Array<Message>>
  {
    return this._httpClient.get<Array<Message>>(UrlConstants.apiUrl+'/Messages/GetMessages/'+receiverId);
  }

  public deleteMessage(id:string)
  {
    return this._httpClient.delete(UrlConstants.apiUrl+'/Messages/Delete/'+id);
  }


}
