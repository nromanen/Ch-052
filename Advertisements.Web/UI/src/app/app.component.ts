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
  providers: [],


})
export class AppComponent implements OnInit, OnDestroy {
 
  title: string = 'Advertisements';
  loginbuttontext: string = 'Log In';
  isLoggedIn:boolean;
  admin:string = 'Admin';

  token:Token;
  subscription: Subscription;

  constructor(private router: Router, private loginService: LoginService, private comcomService: ComcomService) { 
    if (localStorage.getItem('user_name') != null && (localStorage.getItem("access_token") != undefined || localStorage.getItem("access_token") != null))
      {this.loginbuttontext = 'Welcome, ' + localStorage.getItem('user_name');
      this.isLoggedIn = true;}
    else
      {this.loginbuttontext = 'Log In';
      this.isLoggedIn = false;}
  }

  logout():void{
    this.loginService.logout().subscribe();
  }

  ngOnInit(): void {
    this.subscription = this.comcomService.getToken().subscribe(token =>       
      {
        this.token = token; 
        console.log('inside app.component');
        if (token != null || token != undefined)
          {this.loginbuttontext = 'Welcome, ' + token.userName;
          this.isLoggedIn = true;}
        else
          {this.loginbuttontext = 'Log In';
          this.isLoggedIn = false;}
      });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


}
