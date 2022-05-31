import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Brand } from '../../../Models/Brand';
import { BrandService } from '../../../services/brand.service';

@Component({
  selector: 'app-brands-list',
  templateUrl: './brands-list.component.html',
  styleUrls: ['./brands-list.component.css']
})
export class BrandsListComponent implements OnInit 
{
  private brands?:Array<Brand>;
  private brandService:BrandService;
  private router:Router;

  constructor(
    brandService:BrandService,
    router:Router
    ) 
  {
    this.brandService = brandService;
    this.router = router;
  }

  ngOnInit(): void 
  {
    this.brandService.getBrands()
    .subscribe(res => 
      {
        this.brands = res;
      })
  }

  public get getBrands():Array<Brand>|undefined
  {
    return this.brands;
  }

  public editBrand(id:string)
  {
    this.router.navigate(['editBrand',id]);
  }

  public deleteBrand(id:string)
  {
    this.brandService.deleteBrand(id)
    .subscribe(res => 
      {
        console.log(res);
      })
  }

}
