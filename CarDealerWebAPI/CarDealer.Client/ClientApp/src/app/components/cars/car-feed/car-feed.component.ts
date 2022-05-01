import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { pipe } from 'rxjs';
import { CarParametersQueryDTO } from 'src/app/DTOs/CarParametersQueryDTO';
import { PaginatedDTO } from 'src/app/DTOs/PaginatedDTO';
import { Car } from 'src/app/Models/Car';
import { BrandService } from 'src/app/services/brand.service';
import { CarTypeService } from 'src/app/services/car-type.service';
import { CarService } from 'src/app/services/car.service';
import { FuelTypeService } from 'src/app/services/fuel-type.service';

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
  private _isFavoriteVisible:boolean;
  private _carTypeService!:CarTypeService;
  private _fuelTypeService!:FuelTypeService;
  private _router!:Router
  constructor(
    carService:CarService,
    brandService:BrandService,
    carTypeService:CarTypeService,
    fuelTypeService:FuelTypeService,
    router:Router
    ) 
  { 
    this._carService = carService;
    this._paginatedDTO = new PaginatedDTO();
    this._carParametersQueryDTO = new CarParametersQueryDTO();
    this._brandService = brandService;
    this._fuelTypeService = fuelTypeService;
    this._carTypeService = carTypeService;
    this._isFavoriteVisible = false;
    this._router = router;
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

  public getCar(id:string)
  {
    this._router.navigate(['car',id]);
  }

  public getDate():number
  {
    return new Date().getTime();
  }





}
