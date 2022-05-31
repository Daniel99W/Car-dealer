import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CarType } from '../../../Models/CarType';
import { CarTypeService } from '../../../services/car-type.service';

@Component({
  selector: 'app-add-car-type',
  templateUrl: './add-car-type.component.html',
  styleUrls: ['./add-car-type.component.css']
})
export class AddCarTypeComponent implements OnInit 
{
  private carTypeService:CarTypeService;
  private name:FormControl;

  constructor(carTypeService:CarTypeService) 
  { 
    this.name = new FormControl();
    this.carTypeService = carTypeService;
  }

  public get Name()
  {
    return this.name;
  }

  ngOnInit(): void 
  {
  }

  public addCarType()
  {
    let carType = new CarType();
    carType.name = this.name.value;

    this.carTypeService.addCarType(carType)
    .subscribe(res => 
      {
        console.log(res);
      })
  }

}
