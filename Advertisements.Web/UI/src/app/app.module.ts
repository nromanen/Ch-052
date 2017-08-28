import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgModule }             from '@angular/core';
import { Http, XHRBackend, RequestOptions} from '@angular/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { httpFactory} from "./http.factory";

import { AdvertisementService } from './services/advertisement.service';
import { LoginService } from './services/login.service';
import { FeedbackService } from './services/feedback.service';
import { ComcomService } from './services/comcom.service';

import { HighlightDirective } from './directives/highlight.directive';
import { IsLoggedInDirective } from './directives/isloggedin.directive';
import { AdminDirective } from './directives/admin.directive';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    StartComponent,
    FeedbackComponent,
    UsersAdvComponent,
    HighlightDirective,
    IsLoggedInDirective,
    AdminDirective
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule, 
    FormsModule
  ],
  providers: [
    AdvertisementService, 
    LoginService, 
    UsersAdvComponent, 
    FeedbackService,
    ComcomService,
    {
            provide: Http,
            useFactory: httpFactory,
            deps: [XHRBackend, RequestOptions, ComcomService]
    }
  
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
