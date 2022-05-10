import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CarParametersQueryDTO } from '../../../DTOs/CarParametersQueryDTO';
import { PaginatedDTO } from '../../../DTOs/PaginatedDTO';
import { Car } from '../../../Models/Car';
import { BrandService } from '../../../services/brand.service';
import { CarTypeService } from '../../../services/car-type.service';
import { CarService } from '../../../services/car.service';
import { Brand } from '../../../Models/Brand';
import { CarType } from '../../../Models/CarType';
import { Options } from '../../../Models/Options';
import { forkJoin, from } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import { TokenService } from '../../../services/token.service';
import { SecurityService } from '../../../services/security.service';
import { FavoriteCarService } from '../../../services/favorite-car.service';
import { MatDialog } from '@angular/material/dialog';
import { FavoriteCarAddedComponent } from '../../favoriteCarDialogs/favorite-car-added/favorite-car-added.component';

@Component({
  selector: 'app-car-feed',
  templateUrl: './car-feed.component.html',
  styleUrls: ['./car-feed.component.css']
})
export class CarFeedComponent implements OnInit 
{
  private carService!:CarService;
  private paginatedDTO?:PaginatedDTO<Car>;
  private carParametersQueryDTO?:CarParametersQueryDTO;
  private brandService!:BrandService;
  private carTypeService!:CarTypeService;
  private securityService:SecurityService;
  private tokenService:TokenService;
  private favoriteCarService:FavoriteCarService;
  private dialog:MatDialog;

  private searchCarFormGroup!:FormGroup;

  private brands!:Options<Brand>;
  private carTypes!:Options<CarType>;
  private orderBy!:Options<boolean>;
  
  private router!:Router;

  constructor(
    carService:CarService,
    brandService:BrandService,
    carTypeService:CarTypeService,
    securityService:SecurityService,
    router:Router,
    tokenService:TokenService,
    favoriteCarService:FavoriteCarService,
    dialog:MatDialog
    ) 
  { 
    this.carService = carService;
    this.paginatedDTO = new PaginatedDTO();
    this.carParametersQueryDTO = new CarParametersQueryDTO();
    this.brandService = brandService;
    this.carTypeService = carTypeService;
    this.securityService = securityService;
    this.tokenService = tokenService;
    this.favoriteCarService = favoriteCarService;
    this.router = router;
    this.dialog = dialog;
    this.brands = new Options<Brand>();
    this.carTypes = new Options<CarType>();
    this.orderBy = new Options<boolean>();
    this.orderBy.options.push(true);
    this.orderBy.options.push(false);
    this.searchCarFormGroup = new FormGroup({
      ProductionYear:new FormControl(),
      MinPrice:new FormControl(),
      MaxPrice:new FormControl(),
      Title:new FormControl(),
      CarsPerPage:new FormControl(5)
    })
  }

  ngOnInit():void 
  {
    let brandsRes = from(this.brandService.getBrands());
    let carTypesRes = from(this.carTypeService.getCarTypes());
    let paginatedResultRes = from(this.carService.getCars(this.carParametersQueryDTO!));

    forkJoin([brandsRes,carTypesRes,paginatedResultRes])
    .subscribe(res => 
      {
        this.brands.options =  res[0] as Array<Brand>;
        this.carTypes.options =  res[1] as Array<CarType>;
        this.paginatedDTO = res[2];
      })
  }

  public get getPaginatedDTO():PaginatedDTO<Car>|undefined
  {
    return this.paginatedDTO;
  }

  public getCar(id:string)
  {
    this.router.navigate(['car',id]);
  }


  public getCars(page?:number)
  {
    let carParametersQueryDTO = new CarParametersQueryDTO();
    carParametersQueryDTO.productionYear = this.searchCarFormGroup.get('ProductionYear')?.value;
    carParametersQueryDTO.minPrice = this.searchCarFormGroup.get('MinPrice')?.value;
    carParametersQueryDTO.maxPrice = this.searchCarFormGroup.get('MaxPrice')?.value;
    carParametersQueryDTO.title = this.searchCarFormGroup.get('Title')?.value;
    carParametersQueryDTO.carsPerPage = this.searchCarFormGroup.get('CarsPerPage')?.value;
    carParametersQueryDTO.brand = this.brands.selectedOption?.id;
    carParametersQueryDTO.carType = this.carTypes.selectedOption?.id;

    console.log(this.brands.selectedOption);
    
    if(page != null)
      carParametersQueryDTO.page = page;

    this.carService.getCars(carParametersQueryDTO).subscribe((res:PaginatedDTO<Car>) =>
      {
          this.paginatedDTO = res;
          console.log(res);
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

  public setBrandById($event:any)
  {
    this.brands.selectedOption = this.brands.options.filter(value => value.id == $event.target.value)[0];
  }

  public setCarTypeId($event:any)
  {
    this.carTypes.selectedOption = this.carTypes.options.filter(value => value.id == $event.target.value)[0];
  }

  public setOrderBy($event:any)
  {
    this.orderBy.selectedOption = $event.target.value;
  }

  public get getCarTypes():Options<CarType>
  {
    return this.carTypes;
  }

  public get getSearchCarFormGroup():FormGroup
  {
    return this.searchCarFormGroup;
  }

  public set getSearchCarFormGroup(value:FormGroup)
  {
    this.searchCarFormGroup = value;
  }

  public get getOrderBy():Options<boolean>
  {
    return this.orderBy;
  }

  public addToFavorite(carId:string)
  {
    if(this.securityService.isAuthenticated)
    {
      let userId = this.tokenService.getTokenObject().userId;
      this.favoriteCarService.addToFavorite(carId,userId)
      .subscribe(res =>
        {
          this.dialog.open(FavoriteCarAddedComponent,
            {
              data:{
                message:'The car was added with much success',
                icon:'done',
                color:'green'
              }
            })

          console.log(res);
        },err=>
        {
          this.dialog.open(FavoriteCarAddedComponent,
            {
              data:
              {
                message:'This car is already in the favorite list!',
                icon:'clear',
                color:'red'
              }
            })
        })
    }
  }

  public getSecurityService():SecurityService
  {
    return this.securityService;
  }

  public counter(i:number):Array<number>
  {
    let arr = new Array<number>();
    for(let j = 1;j<=i;++j)
    {
      arr.push(j);
    }
    return arr;
  }

  public set getOrderBy(value:Options<boolean>)
  {
    this.orderBy = value;
  }

  public getDate():number
  {
    return new Date().getTime();
  }






}
