import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { AdvertisementService } from '../services/advertisement.service';

@Component({
  selector: 'loggedUserAds',
  templateUrl: './loggedUserAds.component.html',
  styleUrls: ['./loggedUserAds.component.css'],
  providers: [AdvertisementService]
})

export class LoggedUserAdsComponent implements OnInit {
  constructor(private router:Router, private advertisementService: AdvertisementService) { }

  title: string ='Advertisements';
  
  advertisements:Advertisement[];

  getLoggedUserAds():void {
   this.advertisementService.getLoggedUserAds().then(advertisements =>
     {this.advertisements = advertisements;});
}

  ngOnInit(): void {  
    this.getLoggedUserAds();
  }

  deleteLoggedUserAds(feed: Advertisement): void {

    this.advertisementService
          .deleteLoggedUserAds(feed)
          .then(res => {this.getLoggedUserAds();})
          .catch(error => console.log(error));
  }
  redirect(Id: number): void{
    this.router.navigate(['/info', Id]);
  }
}