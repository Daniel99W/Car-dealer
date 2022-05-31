import { Component, OnInit,Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-not-logged',
  templateUrl: './user-not-logged.component.html',
  styleUrls: ['./user-not-logged.component.css']
})
export class UserNotLoggedComponent implements OnInit 
{

  private data:string;

  constructor(@Inject(MAT_SNACK_BAR_DATA) data:string) 
  {
    this.data = data;
  }

  ngOnInit(): void 
  {
  }

  public getData():string 
  {
    return this.data;
  }
}
