import { Component, OnInit } from '@angular/core';
import { Advertisement } from '../models/advertisement';
import { AdvertisementService } from '../services/advertisement.service';
import { Router } from '@angular/router';

@Component({
  selector: 'start-root',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [AdvertisementService]
})
export class StartComponent implements OnInit {
  constructor(private router:Router, private advertisementService: AdvertisementService) { }
  title: string ='Advertisements';
  
  advertisements:Advertisement[];
  selectedAdvertisement:Advertisement;

  getAdvertisements():void {
   this.advertisementService.getAdvertisements().then(result =>
     {this.advertisements = result; console.log(this.advertisements) });
}

  ngOnInit(): void {  
    this.getAdvertisements();
  }

  // goRegister():void{
  //   this.router.navigate(['/registration']);
  // }
}
