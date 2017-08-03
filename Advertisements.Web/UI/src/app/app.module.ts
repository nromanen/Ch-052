import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgModule }             from '@angular/core';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './registration-component/registration.component';
import { StartComponent } from './start-component/start.component';

import { AdvertisementService } from './services/advertisement.service';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    StartComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule, 
    FormsModule
  ],
  providers: [AdvertisementService],
  bootstrap: [AppComponent]
})
export class AppModule { }
