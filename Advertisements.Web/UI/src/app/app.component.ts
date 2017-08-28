import { Component, OnInit, OnDestroy } from '@angular/core';
import { Advertisement } from './models/advertisement';

import { LoginService } from './services/login.service';
import { ComcomService } from './services/comcom.service';

import { Token } from './models/token';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';
import { Notification } from "./models/notification";


@Component({
  moduleId: module.id.toString(),
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit, OnDestroy {
 
  title: string = 'Advertisements';
  loginbuttontext: string = 'Log In';

  token:Token;
  subscription: Subscription;
  errorSubscription: Subscription;
  errorNotification : Notification = new Notification();

  constructor(private router: Router, private loginService: LoginService, private comcomService: ComcomService) {
    this.subscription = this.comcomService.getObservableToken().subscribe(token =>       
      {
        this.token = token; 
        if (token !== null)
          this.loginbuttontext = 'Welcome, ' + token.userName;
        else
          this.loginbuttontext = 'Log In';
      });

      this.errorSubscription = this.comcomService.getNotification().subscribe(error =>       
        {
          this.errorNotification = error; 
          console.log(this.errorNotification);
        });

  }

  ngOnInit(): void {
    this.comcomService.loadTokenFromStorage();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.errorSubscription.unsubscribe();
  }


}
