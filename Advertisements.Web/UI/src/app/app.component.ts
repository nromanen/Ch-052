import { Component, OnInit, OnDestroy } from '@angular/core';
import { Advertisement } from './models/advertisement';

import { LoginService } from './services/login.service';
import { ComcomService } from './services/comcom.service'

import { Token } from './models/token';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';

@Component({
  moduleId: module.id.toString(),
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ComcomService],


})
export class AppComponent implements OnInit, OnDestroy {
 
  title: string = 'Advertisements';
  loginbuttontext: string = 'Log In';

  token:Token;
  subscription: Subscription;
   
  //access_token: string;

  constructor(private router: Router, private loginService: LoginService, private comcomService: ComcomService) {
    this.subscription = this.comcomService.getToken().subscribe(token =>       
      {
        this.token = token; 
        if (token !== null)
          this.loginbuttontext = 'Welcome, ' + token.userName;
        else
          this.loginbuttontext = 'Log In';
      });


    // this.access_token = localStorage.getItem('access_token');
    // console.log('outside');
    // console.log(this.access_token);
    // if (this.access_token !== null) {
    //   console.log('inside');
    // }

  }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


}
