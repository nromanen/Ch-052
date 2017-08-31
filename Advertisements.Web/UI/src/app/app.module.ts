import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { NgModule }             from '@angular/core';
import { Http, XHRBackend, RequestOptions} from '@angular/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login-component/login.component';
import { StartComponent } from './start-component/start.component';
import { FeedbackComponent } from './feedback-component/feedback.component';
import { UsersAdvComponent } from './usersAdv-component/usersAdv.component';
import { EditAdvComponent } from './editAdv-component/editAdv.component';
import { CreateAdvComponent } from './createAdv-component/createAdv.component';
import { AdvInfoComponent } from './advInfo-component/advInfo.component';
import { httpFactory} from "./http.factory";
import { CategoryComponent } from './category-component/category.component';
import { TypeComponent } from './type-component/type.component';
import { UploadFileComponent } from './uploadFile-component/uploadFile.component'

import { AdvertisementService } from './services/advertisement.service';
import { LoginService } from './services/login.service';
import { FeedbackService } from './services/feedback.service';
import { CategoryService } from './services/category.service';
import { ComcomService } from './services/comcom.service';
import { AdvertisementCurrentService } from './services/advertisementCurrent.service';
import { EditAdvService } from './services/editAdv.service';
import { CreateAdvService } from './services/createAdv.service';
import { AdvInfoService } from './services/advInfo.service';
import { RegistrationComponent } from './registration-component/registration.component';
import { EqualValidator  } from "./directives/equalvalidator.directive";
import { RegistrationService } from './services/registration.service';
import { TryRestorePasswordCompoent } from './tryrestorepassword-component/tryrestorepassword.component';
import { RestorePasswordComponent } from "./restorepassword-component/restorepassword.component";
import { RestorePasswordService } from './services/restorepassword.service';
import { TypeService } from './services/type.service';

import { HighlightDirective } from './directives/highlight.directive';
import { IsLoggedInDirective } from './directives/isloggedin.directive';
import { AdminDirective } from './directives/admin.directive';
import { ConfirmEmailComponent } from "./confirmemail-component/confirmemail.component";
import { ConfirmEmailService } from "./services/confirmemail.service";

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    StartComponent,
    FeedbackComponent,
    RegistrationComponent,
    EqualValidator,
    TryRestorePasswordCompoent,
    RestorePasswordComponent,
    EditAdvComponent,
    CreateAdvComponent,
    AdvInfoComponent,
    UsersAdvComponent,
    HighlightDirective,
    IsLoggedInDirective,
    AdminDirective,
    ConfirmEmailComponent,
    CategoryComponent,
    TypeComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    AppRoutingModule, 
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AdvertisementService, 
    LoginService, 
     
    FeedbackService,
      ComcomService,
      AdvertisementCurrentService, 
      EditAdvService, 
      CreateAdvService, 
      AdvInfoService, 
      RegistrationService, 
      TryRestorePasswordCompoent, 
      CategoryService,
      TypeService,
      RestorePasswordService,
      ConfirmEmailService,
    {
            provide: Http,
            useFactory: httpFactory,
            deps: [XHRBackend, RequestOptions, ComcomService]
    }
  
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
