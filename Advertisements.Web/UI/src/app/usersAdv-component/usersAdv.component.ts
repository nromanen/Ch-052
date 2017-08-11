import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { AdvertisementCurrentService } from '../services/advertisementCurrent.service';

@Component({
  selector: 'usersAdv',
  templateUrl: './usersAdv.component.html',
  styleUrls: ['./usersAdv.component.css']
})

export class UsersAdvComponent implements OnInit {
  constructor(private router:Router, private advertisementCurrentService: AdvertisementCurrentService) { }
  title: string ='Advertisements';
  
  advertisements:string[];
  selectedAdvertisement:Advertisement;

  getCurrentAdvertisements():void {
   this.advertisementCurrentService.getCurrentAdvertisements().then(advertisements =>
     {this.advertisements = advertisements; console.log(this.advertisements) });
}

  ngOnInit(): void {  
    this.getCurrentAdvertisements();
  }

}