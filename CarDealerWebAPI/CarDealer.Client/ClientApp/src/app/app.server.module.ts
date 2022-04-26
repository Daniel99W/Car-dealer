import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';

@NgModule({
    imports: [
        AppModule, 
        ServerModule,
        AppRoutingModule
    ],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
