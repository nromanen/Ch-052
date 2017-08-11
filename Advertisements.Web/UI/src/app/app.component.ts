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
}
