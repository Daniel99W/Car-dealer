import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CarFeedComponent } from '../components/cars/car-feed/car-feed.component';
import { AddCarComponent } from '../components/cars/add-car/add-car.component';
import { EditCarComponent } from '../components/cars/edit-car/edit-car.component';
import { CarPageComponent } from '../components/cars/car-page/car-page.component';
import { FavoritesComponent } from '../components/cars/favorites/favorites.component';
import { SignUpComponent } from '../components/sign-up/sign-up.component';
import { LoginComponent } from '../components/login/login.component';
import { UsersCarComponent } from '../components/users-car/users-car.component';
import { AddBrandComponent } from '../components/brands/add-brand/add-brand.component';
import { BrandsListComponent } from '../components/brands/brands-list/brands-list.component';
import { EditBrandComponent } from '../components/brands/edit-brand/edit-brand.component';
import { AddCarTypeComponent } from '../components/carTypes/add-car-type/add-car-type.component';
import { CarTypesListComponent } from '../components/carTypes/car-types-list/car-types-list.component';
import { EditCarTypeComponent } from '../components/carTypes/edit-car-type/edit-car-type.component';
import { EditUserComponent } from '../components/users/edit-user/edit-user.component';
import { AuthGuardService as AuthGuard } from '../services/auth-guard.service';
import { UserTypes } from '../Constants/UserTypes';

const routes:Routes =
[
  {path:'carFeed',component:CarFeedComponent},
  {
  path:'addCar',
  component:AddCarComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.USER
  }},
  {
  path:'editCar/:id',
  component:EditCarComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.USER
  }},
  {path:'car/:id',component:CarPageComponent},
  {
  path:'favorites',
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.USER
  },
  component:FavoritesComponent},
  {path:'signUp',component:SignUpComponent},
  {path:'login',component:LoginComponent},
  {
    path:'addCar',
    canActivate:[AuthGuard],
    component:AddCarComponent,
    data:
    {
      role:UserTypes.USER
    }},
  {
  path:'usersCar/:userId',
  component:UsersCarComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.USER
  }},
  {
    path:'addBrand',
    component:AddBrandComponent,
    canActivate:[AuthGuard],
    data:
    {
      role:UserTypes.ADMIN
    }},
  {
  path:'brands',
  component:BrandsListComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.ADMIN
  }},
  {
  path:'editBrand/:id',
  component:EditBrandComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.ADMIN,
  }},
  {
  path:'addCarType',
  component:AddCarTypeComponent,
  canActivate:[AuthGuard],
  data:
  {
    role:UserTypes.ADMIN
  }},
  {
    path:'carTypes',
    component:CarTypesListComponent,
    canActivate:[AuthGuard],
    data:
    {
      role:UserTypes.ADMIN
    }
  },
  {
    path:'editCarType/:id',
    component:EditCarTypeComponent,
    canActivate:[AuthGuard],
    data:
    {
      role:UserTypes.ADMIN
    }},
  {
  path:'user/:id',component:EditUserComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
