import { Component, OnInit } from '@angular/core';
import { forkJoin, from } from 'rxjs';
import { BrandService } from 'src/app/services/brand.service';
import { CarTypeService } from 'src/app/services/car-type.service';
import { FuelTypeService } from 'src/app/services/fuel-type.service';
import { Brand } from '../../../Models/Brand';
import { CarType } from '../../../Models/CarType';
import { FuelType } from '../../../Models/FuelType';
import { FormControl, FormGroup } from '@angular/forms';
import { Options } from '../../../Models/Options';
import { CarService } from '../../../services/car.service';
import { CreateCarDTO } from '../../../DTOs/CreateCarDTO';
import { TokenService } from '../../../services/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit 
{
  private brandService:BrandService;
  private carTypeService:CarTypeService;
  private fuelTypeService:FuelTypeService;
  private carService:CarService;
  private tokenService:TokenService;
  private router:Router;

  private IsSecondHand:boolean;

  private form:FormGroup;

  private images:any[];

  private brands!:Options<Brand>;
  private carTypes!:Options<CarType>;
  private fuelTypes!:Options<FuelType>;

  constructor(
    brandService:BrandService,
    carTypeService:CarTypeService,
    fuelTypeService:FuelTypeService,
    carService:CarService,
    tokenService:TokenService,
    router:Router
    ) 
  {
    this.brandService = brandService;
    this.carTypeService = carTypeService;
    this.fuelTypeService = fuelTypeService;
    this.carService = carService;
    this.tokenService = tokenService;
    this.router = router;
    this.IsSecondHand = false;
    this.brands = new Options<Brand>();
    this.carTypes = new Options<CarType>();
    this.fuelTypes = new Options<FuelType>();
    this.images = [];
    this.form = new FormGroup(
      {
        title:new FormControl(),
        carNumber:new FormControl(),
        productionYear:new FormControl(),
        price:new FormControl(),
        addingDate:new FormControl(),
        description:new FormControl(),
        modelName:new FormControl(),
        cilindricCapacity:new FormControl(),
        secondHand:new FormControl(false)
      });

  }

  ngOnInit(): void 
  {
    let brandsRes = from(this.brandService.getBrands());
    let carTypesRes = from(this.carTypeService.getCarTypes());
    let fuelTypesRes = from(this.fuelTypeService.getFuelTypes());

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

  public get formGroup():FormGroup
  {
    return this.form;
  }

  public set formGroup(value:FormGroup)
  {
    this.form = value;
  }

  public get secondHand():boolean
  {
    return this.IsSecondHand;
  }
  public set secondHand(value:boolean)
  {
    this.IsSecondHand = value;
  }

  public get getImages():any[]
  {
    return this.images;
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

  public set getImages(value:File[])
  {
    this.images = value;
  }

  public onFileChange(event:any)
  {
    this.images = event.target.files;
  }


  public addCar()
  {
    let createCarDTO = new CreateCarDTO(
      this.form.get('title')!.value,
      this.form.get('carNumber')!.value,
      this.form.get('productionYear')!.value,
      this.form.get('price')!.value,
      this.form.get('secondHand')!.value,
      this.form.get('addingDate')!.value,
      this.tokenService.getTokenObject()!.userId,
      this.form.get('description')!.value,
      this.form.get('modelName')!.value,
      this.form.get('cilindricCapacity')!.value,
      this.fuelTypes.selectedOption?.id,
      this.brands.selectedOption?.id,
      this.carTypes.selectedOption?.id,
      );
    this.carService.addCar(createCarDTO,this.images)
    .subscribe(
      res => 
      this.router.navigate(['carFeed']));
  }






}
