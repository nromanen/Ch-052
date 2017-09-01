import { Component, OnInit } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { AdvertisementService } from '../services/advertisement.service';
import { LoginService } from '../services/login.service';
import { Token } from '../models/token';
import { Router } from '@angular/router';

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
   this.advertisementService.getAdvertisements().then(result => {this.advertisements = result; });   
}

  ngOnInit(): void {  
    this.getAdvertisements();
  }

  redirect(Id: number): void{
    this.router.navigate(['/info', Id]);
  }
}
