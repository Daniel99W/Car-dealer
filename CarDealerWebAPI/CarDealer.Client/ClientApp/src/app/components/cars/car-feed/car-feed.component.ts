import { Component, OnInit } from '@angular/core';
import { pipe } from 'rxjs';
import { CarParametersQueryDTO } from 'src/app/DTOs/CarParametersQueryDTO';
import { PaginatedDTO } from 'src/app/DTOs/PaginatedDTO';
import { Car } from 'src/app/Models/Car';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-feed',
  templateUrl: './car-feed.component.html',
  styleUrls: ['./car-feed.component.css']
})
export class CarFeedComponent implements OnInit 
{
  private _carService!:CarService;
  private _paginatedDTO?:PaginatedDTO<Car>;
  private _carParametersQueryDTO?:CarParametersQueryDTO;
  private _brandService?:BrandService;

  constructor(CarService:CarService,BrandService:BrandService) 
  { 
    this._carService = CarService;
    this._paginatedDTO = new PaginatedDTO();
    this._carParametersQueryDTO = new CarParametersQueryDTO();
    this._brandService = BrandService;
  }

  ngOnInit():void 
  {

    this._carService.getCars(this._carParametersQueryDTO!)
    .subscribe(res => 
    {
      this._paginatedDTO = res;
      this._paginatedDTO.results = 
      Object.values(Object.values(res.results)[1]);
      console.log(this._paginatedDTO)

    })

 
  }


  public get paginatedDTO():PaginatedDTO<Car>|undefined
  {
    return this._paginatedDTO;
  }



}
