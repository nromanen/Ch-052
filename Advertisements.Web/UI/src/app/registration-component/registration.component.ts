import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';

import { AdvertisementService } from '../services/advertisement.service';

import { RegisterViewModel } from '../models/register.view.model';

import 'rxjs/add/operator/switchMap';
import { Login } from "../models/login";


@Component({
  selector: 'advertisement-registration',
  templateUrl: `./registration.component.html`,
  styleUrls: [`./registration.component.css`],
//   styleUrls: [`./registration-detail.component.css`],
providers: [AdvertisementService]
})

export class RegistrationComponent implements OnInit{
constructor(
                private advertisementService: AdvertisementService,
                private route: ActivatedRoute,
                private location: Location
            ) {}
           

@Input() registerViewModel: RegisterViewModel = new RegisterViewModel;
login: Login;

  ngOnInit(): void {
    console.log(this);
    // this.route.paramMap
    // .switchMap(() => this.advertisementService.getAdvertisements())
    // .subscribe(x => this.advertisement = x);
  }

  goClick(): void {
    
    this.registerViewModel.Username = this.registerViewModel.Email;
    this.registerViewModel.grant_type = 'password';

    


    this.advertisementService.login(this.registerViewModel).then((gotData) => this.login = gotData);
      console.log(this.registerViewModel.Email);
      console.log(this.registerViewModel.Password);
      console.log(this.login);
  }

//   goBack(): void {
//     this.location.back();
// }

//   save(): void {
//     this.advertisementService.update(this.advertisement).then(() => this.goBack());
// }
}