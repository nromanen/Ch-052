import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgModule }             from '@angular/core';

import { AppComponent } from './app.component';
import { LoginComponent } from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { FeedbackComponent } from './feedback-component/feedback.component';

import { AdvertisementService } from './services/advertisement.service';
import { LoginService } from './services/login.service';
import { FeedbackService } from './services/feedback.service';
import { ComcomService } from './services/comcom.service';
import {RegistrationComponent} from './registration-component/registration.component'
import { EqualValidator  } from "./directives/equalvalidator.directive";
import {RegistrationService} from './services/registration.service'
import {TryRestorePasswordCompoent} from './tryrestorepassword-component/tryrestorepassword.component'
import {RestorePasswordComponent  } from "./restorepassword-component/restorepassword.component"
import {RestorePasswordService} from './services/restorepassword.service'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    StartComponent,
    FeedbackComponent,
    UsersAdvComponent,
    RegistrationComponent,
    EqualValidator,
    TryRestorePasswordCompoent,
    RestorePasswordComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AdvertisementService, LoginService, FeedbackService, ComcomService, RegistrationService, TryRestorePasswordCompoent, RestorePasswordService],
  bootstrap: [AppComponent]
})
export class AppModule { }
