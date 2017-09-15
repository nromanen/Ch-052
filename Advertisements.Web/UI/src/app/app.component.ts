import { Component, OnInit, OnDestroy } from '@angular/core';
import { Advertisement } from './models/advertisement';

import { LoginService } from './services/login.service';
import { ComcomService } from './services/comcom.service';

import { Token } from './models/token';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';
import { Notification } from "./models/notification";
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { SearchModel } from "./models/searchmodel";

@Component({
  moduleId: module.id.toString(),
  selector: 'app-root',                       
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: []
})
export class AppComponent implements OnInit, OnDestroy {
 
  title: string = 'Advertisements';
  loginbuttontext: string = 'Log In';
  isLoggedIn:boolean;
  admin:string = 'Admin';
  registerbuttontext: string = 'Register';

  token:Token;
  subscription: Subscription;
  errorSubscription: Subscription;
  errorNotification : Notification = new Notification();
  public searchGroup: FormGroup;

  constructor(private router: Router, private loginService: LoginService, private comcomService: ComcomService) {
    this.subscription = this.comcomService.getObservableToken().subscribe(token =>       
      {
        this.token = token; 
        if (token != null || token != undefined) {
          this.loginbuttontext = 'Welcome, ' + token.userName;
              this.isLoggedIn = true;
          }
          else {
          this.loginbuttontext = 'Log In';
              this.isLoggedIn = false;
          }
      });

      this.errorSubscription = this.comcomService.getNotification().subscribe(error =>       
        {
          this.errorNotification = error; 
        });

  }

  public GoSearch(model: SearchModel):void
  {
     // window.location.replace('/search?keyword='+model.Key);
      
      this.router.navigate(['/search'], {queryParams: { keyword: model.Key }});  
          
  }

  logout(): void {
      this.loginService.logout().subscribe((result)=>window.location.replace("/start"));

      this.comcomService.clearObservableRole();
      this.comcomService.clearObservableToken();
  }

  ngOnInit(): void {

    this.searchGroup = new FormGroup({
        Key: new FormControl()
    });

      this.comcomService.loadTokenFromStorage();

      this.subscription = this.comcomService.getObservableToken().subscribe(token => {
          this.token = token;
          if (token != null || token != undefined) {
          this.loginbuttontext = 'Welcome, ' + token.userName;
              this.isLoggedIn = true;
          }
          else {
          this.loginbuttontext = 'Log In';
              this.isLoggedIn = false;
          }
      });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.errorSubscription.unsubscribe();
  }


}
