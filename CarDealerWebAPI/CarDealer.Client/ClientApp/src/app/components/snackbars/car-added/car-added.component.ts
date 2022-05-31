import { Component, Inject, OnInit } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-car-added',
  templateUrl: './car-added.component.html',
  styleUrls: ['./car-added.component.css']
})
export class CarAddedComponent implements OnInit
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
