import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
import { Advertisement } from '../models/advertisement';
import { AdvertisementService } from '../services/advertisement.service';
import { Router } from '@angular/router';

@Component({
=======
import { NgSwitch } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { AdvertisementService } from '../services/advertisement.service';
import { LoginService } from '../services/login.service';
import { Token } from '../models/token';
import { Router } from '@angular/router';

@Component({
  moduleId: module.id.toString(),
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
  selector: 'start-root',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [AdvertisementService]
})
export class StartComponent implements OnInit {
<<<<<<< HEAD
  constructor(private router:Router, private advertisementService: AdvertisementService) { }
  title: string ='Advertisements';
  
  advertisements:string[];
  selectedAdvertisement:Advertisement;

  getAdvertisements():void {
   this.advertisementService.getAdvertisements().then(advertisements =>
     {this.advertisements = advertisements; console.log(this.advertisements) });
=======
  token:Token;   
  
  constructor(private router:Router, private advertisementService: AdvertisementService, private loginService: LoginService) { }
  title: string ='Advertisements';
  
  advertisements:Advertisement[];
  selectedAdvertisement:Advertisement;

  getAdvertisements():void {
   this.advertisementService.getAdvertisements().then(result => {this.advertisements = result; });   
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
}

  ngOnInit(): void {  
    this.getAdvertisements();
  }

<<<<<<< HEAD
  // goRegister():void{
  //   this.router.navigate(['/registration']);
  // }
=======
  redirect(Id: number): void{
    this.router.navigate(['/info', Id]);
  }
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
}
