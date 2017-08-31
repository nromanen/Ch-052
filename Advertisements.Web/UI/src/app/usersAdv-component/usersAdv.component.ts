import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { AdvertisementCurrentService } from '../services/advertisementCurrent.service';

@Component({
    moduleId: module.id.toString(),
  selector: 'usersAdv',
  templateUrl: './usersAdv.component.html',
  styleUrls: ['./usersAdv.component.css'],
  providers: [AdvertisementCurrentService]
})

export class UsersAdvComponent implements OnInit {
  constructor(private router:Router, private advertisementCurrentService: AdvertisementCurrentService) { }

  title: string ='Advertisements';
  
  advertisements:Advertisement[];

  getCurrentAdvertisements():void {
   this.advertisementCurrentService.getCurrentAdvertisements().then(advertisements =>
     {this.advertisements = advertisements;});
}

  ngOnInit(): void {  
    this.getCurrentAdvertisements();
  }

  remove(feed: Advertisement): void {

    this.advertisementCurrentService
          .deleteCurrentAdv(feed)
          .then(feedback => {this.getCurrentAdvertisements();})
          .catch(error => console.log(error));
  }
  redirect(Id: number): void{
    this.router.navigate(['/info', Id]);
  }
}