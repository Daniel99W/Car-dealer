import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CarFeedComponent } from './components/cars/car-feed/car-feed.component';
import { AddCarComponent } from './components/cars/add-car/add-car.component';
import { EditCarComponent } from './components/cars/edit-car/edit-car.component';
import { CarPageComponent } from './components/cars/car-page/car-page.component';
import { EditUserComponent } from './components/users/edit-user/edit-user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { FavoritesComponent } from './components/cars/favorites/favorites.component';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/sign-up/sign-up.component'; 
import {MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS} from '@angular/material/form-field'; 
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button'; 
import { JwtHelperService,JWT_OPTIONS } from '@auth0/angular-jwt';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDialogModule} from '@angular/material/dialog';
import { FavoriteCarAddedComponent } from './components/favoriteCarDialogs/favorite-car-added/favorite-car-added.component'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarFeedComponent,
    AddCarComponent,
    EditCarComponent,
    CarPageComponent,
    EditUserComponent,
    FavoritesComponent,
    LoginComponent,
    SignUpComponent,
    FavoriteCarAddedComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatToolbarModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    AngularEditorModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  providers: [
    JwtHelperService,{provide:JWT_OPTIONS,useValue:JWT_OPTIONS},
    {provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: {appearance: 'fill'}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
