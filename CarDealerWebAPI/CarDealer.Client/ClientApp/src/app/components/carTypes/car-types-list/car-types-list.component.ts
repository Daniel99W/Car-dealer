import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarType } from '../../../Models/CarType';
import { CarTypeService } from '../../../services/car-type.service';

@Component({
  selector: 'app-car-types-list',
  templateUrl: './car-types-list.component.html',
  styleUrls: ['./car-types-list.component.css']
})
export class CarTypesListComponent implements OnInit 
{
  private carTypeService:CarTypeService;
  private carTypes!:Array<CarType>;
  private router:Router;

  constructor(
    carTypeService:CarTypeService,
    router:Router
    ) 
  {
    this.carTypeService = carTypeService;
    this.router = router;
  }

  ngOnInit(): void 
  {
    this.carTypeService.getCarTypes()
    .subscribe(res =>
      {
        this.carTypes = res;
      })
  }

  public get getCarTypes():Array<CarType>
  {
    return this.carTypes;
  }

  public editCarType(id:string)
  {
    this.router.navigate(['editCarType',id]);
  }

  public deleteCarType(id:string)
  {
    this.carTypeService.deleteCarType(id);
  }

}
