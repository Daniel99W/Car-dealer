import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Brand } from '../../../Models/Brand';
import { BrandService } from '../../../services/brand.service';

@Component({
  selector: 'app-add-brand',
  templateUrl: './add-brand.component.html',
  styleUrls: ['./add-brand.component.css']
})
export class AddBrandComponent implements OnInit 
{
  private brandService:BrandService;
  private name:FormControl;
  private description:FormControl;

  constructor(brandService:BrandService) 
  {
    this.brandService = brandService;
    this.name = new FormControl();
    this.description = new FormControl();
  }

  ngOnInit(): void 
  {
   
  }

  public get getName():FormControl
  {
    return this.name;
  }

  public get getDescription():FormControl
  {
    return this.description;
  }


  public addBrand()
  {
    this.brandService.addBrand(new Brand(this.name.value,this.description.value))
    .subscribe(res =>
      {
        console.log(res);
      })
  }

}
