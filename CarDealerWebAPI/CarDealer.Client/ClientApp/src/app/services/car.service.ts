
import { HttpClient } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { UrlConstants } from '../Constants/UrlConstants';
import { CarParametersQueryDTO } from '../DTOs/CarParametersQueryDTO';
import { CreateCarDTO } from '../DTOs/CreateCarDTO';
import { PaginatedDTO } from '../DTOs/PaginatedDTO';

import { Car } from '../Models/Car';

@Injectable({
  providedIn: 'root'
})
export class CarService 
{
  private _httpClient:HttpClient;

  constructor(http:HttpClient) 
  { 
    this._httpClient = http;
  }

  public getCars(carParametersQueryDTO:CarParametersQueryDTO):Observable<PaginatedDTO<Car>>
  {
    let body = 
    {
      Page:carParametersQueryDTO.page,
      CarsPerPage:carParametersQueryDTO.carsPerPage,
      BrandId:carParametersQueryDTO.brand,
      CarTypeId:carParametersQueryDTO.carType,
      UserId:carParametersQueryDTO.userId,
      Title:carParametersQueryDTO.title,
      MinProductionYear:carParametersQueryDTO.minProductionYear,
      MaxProductionYear:carParametersQueryDTO.maxProductionYear,
      MinPrice:carParametersQueryDTO.minPrice,
      MaxPrice:carParametersQueryDTO.maxPrice
    }
    return this._httpClient.post<PaginatedDTO<Car>>(UrlConstants.apiUrl+'/Cars/GetCars',body);
  }

  public getCar(id:string)
  {
    return this._httpClient.get<Car>(UrlConstants.apiUrl+`/Cars/GetCar/${id}`);
  }

  public getCarsByUserId(userId:string)
  {
    return this._httpClient.get<Array<Car>>(UrlConstants.apiUrl+`/Cars/GetCarsByUserId/`+userId);
  }


  public addCar(createCarDTO:CreateCarDTO,images:any[]):Observable<any>
  {
    let formData:FormData = new FormData();

    formData.append('Title',createCarDTO.title);
    formData.append('CarNumber',createCarDTO.CarNumber);
    formData.append('ProductionYear',createCarDTO.productionYear.toString());
    formData.append('Price',createCarDTO.price.toString());
    formData.append('SecondHand',createCarDTO.secondHand.toString());
    formData.append('AddingDate',createCarDTO.addingDate);
    formData.append('UserId',createCarDTO.userId);
    formData.append('FuelType',createCarDTO.fuelTypeId!);
    formData.append('Description',createCarDTO.description);
    formData.append('Model',createCarDTO.model);
    formData.append('CilindricCapacity',createCarDTO.cilindricCapacity.toString());
    formData.append('BrandId',createCarDTO.brandId!);
    formData.append('CarTypeId',createCarDTO.carTypeId!);


    for(let i = 0;i<images.length;++i)
      formData.append('Images',images[i],images[i].name);

    return this._httpClient.post<any>(UrlConstants.apiUrl+'/Cars/PostCar',formData); 
  }

  public deleteCar(carId:string)
  {
    return this._httpClient.delete(UrlConstants.apiUrl+'/Cars/DeleteCar/'+carId);
  }

  public editCar(car:Car)
  {
    console.log(car.id);
    let body =
    {
      Id:car.id,
      Title:car.title,
      CarNumber:car.carNumber,
      ProductionYear:car.productionYear,
      Price:car.price,
      SecondHand:car.secondHand,
      AddingDate:car.addingDate,
      Description:car.description,
      Model:car.model,
      CilindricCapacity:car.cilindricCapacity,
      FuelType:car.fuelType,
      BrandId:car.brand?.id,
      CarTypeId:car.carType?.id,
      UserId:car.userId
    }

    return this._httpClient.post(UrlConstants.apiUrl+'/Cars/Update',body);
  }

  public getCarsNumber(userId:string|undefined):Observable<number>
  {
    let url = UrlConstants.apiUrl+'/Cars/GetCarsNumber';

    if(userId != undefined)
    {
      url = url + '/' + userId;
      return this._httpClient.get<number>(url);
    }
    return this._httpClient.get<number>(url);
  }




}
