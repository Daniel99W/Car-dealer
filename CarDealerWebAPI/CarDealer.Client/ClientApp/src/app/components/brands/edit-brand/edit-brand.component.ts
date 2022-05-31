import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Brand } from '../../../Models/Brand';
import { BrandService } from '../../../services/brand.service';

@Component({
  selector: 'app-edit-brand',
  templateUrl: './edit-brand.component.html',
  styleUrls: ['./edit-brand.component.css']
})
export class EditBrandComponent implements OnInit 
{
  private brandService:BrandService;
  private brand!:Brand;
  private activatedRoute:ActivatedRoute;

  constructor(
    brandService:BrandService,
    activateRoute:ActivatedRoute) 
  { 
    this.brandService = brandService;
    this.activatedRoute = activateRoute;
  }

  ngOnInit(): void
  {
    this.activatedRoute.params.subscribe(params =>
      {
        this.brandService.getBrand(params['id'])
        .subscribe(res => 
          {
            this.brand = res;
            console.log(res);
          })
      })
  }

  public get getBrand():Brand
  {
    return this.brand;
  }

  public set getBrand(value:Brand)
  {
    this.brand = value;
  }


  public editBrand()
  {
    this.brandService.editBrand(this.brand)
    .subscribe(res => 
      {
        console.log(res);
      })
  }

}
