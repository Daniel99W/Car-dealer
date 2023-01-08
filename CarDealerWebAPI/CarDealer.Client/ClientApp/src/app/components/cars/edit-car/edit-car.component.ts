import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/Models/Brand';
import { CarType } from 'src/app/Models/CarType';
import { FuelType } from 'src/app/Models/FuelType';
import { Options } from 'src/app/Models/Options';
import { BrandService } from 'src/app/services/brand.service';
import { CarTypeService } from 'src/app/services/car-type.service';
import { FuelTypeService } from 'src/app/services/fuel-type.service';
import { Car } from '../../../Models/Car';
import { CarService } from '../../../services/car.service';
import { forkJoin, from } from 'rxjs';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit 
{

  private carService:CarService;
  private activatedRouter:ActivatedRoute;
  private brandService:BrandService;
  private carTypeService:CarTypeService;
  private fuelTypeService:FuelTypeService;
  private brands!:Options<Brand>;
  private carTypes!:Options<CarType>;
  private fuelTypes!:Options<FuelType>;
  private car?:Car;

  constructor(
    carService:CarService,
    brandService:BrandService,
    carTypeService:CarTypeService,
    fuelTypeService:FuelTypeService,
    activatedRouter:ActivatedRoute
    ) 
  { 
    this.carService = carService;
    this.brandService = brandService;
    this.carTypeService = carTypeService;
    this.fuelTypeService = fuelTypeService;
    this.activatedRouter = activatedRouter;
    this.brands = new Options<Brand>();
    this.carTypes = new Options<CarType>();
    this.fuelTypes = new Options<FuelType>();
  }

  ngOnInit(): void 
  {

    let brandsRes = from(this.brandService.getBrands());
    let carTypesRes = from(this.carTypeService.getCarTypes());
    let fuelTypesRes = from(this.fuelTypeService.getFuelTypes());

    this.activatedRouter.params.subscribe(params =>
      {
        this.carService.getCar(params['id'])
        .subscribe(res => 
          {
            this.car = res;
          })
      })

    forkJoin([brandsRes,carTypesRes,fuelTypesRes])
    .subscribe(res => 
      {

        this.brands.options =  res[0] as Array<Brand>;
        this.carTypes.options =  res[1] as Array<CarType>;
        this.fuelTypes.options = res[2] as Array<FuelType>;
        this.brands.selectedOption = this.brands.options[0];
        this.carTypes.selectedOption = this.carTypes.options[0];
        this.fuelTypes.selectedOption = this.fuelTypes.options[0];
      })

  }


  public get getCar():Car|undefined
  {
    return this.car;
  }

  public set getCar(value:Car|undefined)
  {
    this.car = value;
  }

  public setBrandId($event:any)
  {
    this.brands.selectedOption = this.brands.options.filter(value => value.id == $event.target.value)[0];
  }

  public setCarTypeId($event:any)
  {
    this.carTypes.selectedOption = this.carTypes.options.filter(value => value.id == $event.target.value)[0];
  }

  public setFuelTypeId($event:any)
  {
    this.fuelTypes.selectedOption = this.fuelTypes.options.filter(value => value.id == $event.target.value)[0];
  }

  public get getBrands():Options<Brand>
  {
    return this.brands;
  }

  public set getBrands(value:Options<Brand>)
  {
    this.brands = value;
  }

  public get getCarTypes():Options<CarType>
  {
    return this.carTypes;
  }

  public get getFuelTypes():Options<FuelType>
  {
    return this.fuelTypes;
  }

  public editCar()
  {
    
     this.carService.editCar(this.car!)
     .subscribe(res => 
      {
        console.log(res);
      })
  }

}
