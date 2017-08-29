import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgModule }             from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { CategoryComponent } from './category-component/category.component';
import { TypeComponent } from './type-component/type.component';

import { AdvertisementService } from './services/advertisement.service';
import { LoginService } from './services/login.service';
import { FeedbackService } from './services/feedback.service';
import { CategoryService } from './services/category.service';
import { ComcomService } from './services/comcom.service';
import { TypeService } from './services/type.service';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    StartComponent,
    FeedbackComponent,
    UsersAdvComponent,
    CategoryComponent,
    TypeComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule, 
    FormsModule
  ],
  providers: [AdvertisementService, LoginService, FeedbackService, ComcomService, CategoryService, TypeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
