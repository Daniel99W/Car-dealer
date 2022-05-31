import { Component, OnInit,Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-car-is-already-added',
  templateUrl: './car-is-already-added.component.html',
  styleUrls: ['./car-is-already-added.component.css']
})
export class CarIsAlreadyAddedComponent implements OnInit {

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
