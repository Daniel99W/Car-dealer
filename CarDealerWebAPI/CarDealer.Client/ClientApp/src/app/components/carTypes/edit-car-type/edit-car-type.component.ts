import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarType } from '../../../Models/CarType';
import { CarTypeService } from '../../../services/car-type.service';

@Component({
  selector: 'app-edit-car-type',
  templateUrl: './edit-car-type.component.html',
  styleUrls: ['./edit-car-type.component.css']
})
export class EditCarTypeComponent implements OnInit {

  private carTypeService:CarTypeService;
  private carType!:CarType;
  private activatedRoute:ActivatedRoute;

  constructor(
    carTypeService:CarTypeService,
    activateRoute:ActivatedRoute) 
  { 
    this.carTypeService = carTypeService;
    this.activatedRoute = activateRoute;
  }

  ngOnInit(): void 
  {
    this.activatedRoute.params.subscribe(params =>
      {
        this.carTypeService.getCarType(params['id'])
        .subscribe(res => 
          {
            this.carType = res;
          })
      })
  }

  public get getCarType():CarType
  {
    return this.carType;
  }

  public set getCarType(value:CarType)
  {
    this.carType = value;
  }

  public editCarType()
  {
    this.carTypeService.editCarType(this.carType)
    .subscribe(res =>
      {
        console.log(res);
      })
  }

}
