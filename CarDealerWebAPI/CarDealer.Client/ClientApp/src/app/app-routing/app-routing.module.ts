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

const routes:Routes =
[
  {path:'carFeed',component:CarFeedComponent},
  {path:'addCar',component:AddCarComponent},
  {path:'editcar',component:EditCarComponent},
  {path:'car/:id',component:CarPageComponent},
  {path:'favorites',component:FavoritesComponent},
  {path:'signUp',component:SignUpComponent},
  {path:'login',component:LoginComponent}
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
