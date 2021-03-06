<<<<<<< HEAD
import { Component, OnInit } from '@angular/core';
import { Advertisement } from './models/advertisement';
import { AdvertisementService } from './services/advertisement.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [AdvertisementService]
})
export class AppComponent {
  //constructor(private router:Router, private advertisementService: AdvertisementService) { }
  title: string ='Advertisements';
  
//   Advertisements:Advertisement[];
//   selectedAdvertisement:Advertisement;

//   getAdvertisements():void {
//    this.advertisementService.getAdvertisements().then(advertisements =>
//      this.Advertisements = advertisements);
// }

//   ngOnInit(): void {  
//     this.getAdvertisements();
//   }

//   goRegister():void{
//     this.router.navigate(['/registration']);
//   }
=======
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

  logout(): void {
      this.loginService.logout().subscribe();
  }

  ngOnInit(): void {
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


>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
}
