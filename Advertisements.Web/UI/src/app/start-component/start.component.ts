import { Component, OnInit } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Router } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { LoginService } from '../services/login.service';

import { Token } from '../models/token';
import { Advertisement } from '../models/advertisement';

@Component({
  moduleId: module.id.toString(),
  selector: 'start-root',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [AdvertisementService]
})
export class StartComponent implements OnInit {
  token:Token;   
  
  constructor(private router:Router, private advertisementService: AdvertisementService, private loginService: LoginService) { }
  title: string ='Advertisements';
  
  advertisements:Advertisement[];
  selectedAdvertisement:Advertisement;

  getAdvertisements():void {
   this.advertisementService.getAds().then(result => {this.advertisements = result; });   
}

  ngOnInit(): void {  
    this.getAdvertisements();
  }

  redirect(Id: number): void{
    this.router.navigate(['/info', Id]);
  }
}
