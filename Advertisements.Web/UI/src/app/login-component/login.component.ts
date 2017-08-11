import { Component, Input } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

import { LoginService } from '../services/login.service';

import { RegisterViewModel } from '../models/register.view.model';

import 'rxjs/add/operator/switchMap';

import { Token } from "../models/token";

@Component({
  selector: 'advertisement-registration',
  templateUrl: `./login.component.html`,
  styleUrls: [`./login.component.css`]
})

export class LoginComponent {
constructor(
                private loginService: LoginService,
                //private route: ActivatedRoute,
                private location: Location,
                private router: Router
            ) {}
           

@Input() registerViewModel: RegisterViewModel = new RegisterViewModel;

  goClick(): void {
    
    this.registerViewModel.Username = this.registerViewModel.Email;
    this.registerViewModel.grant_type = 'password';

    this.loginService.login(this.registerViewModel).then( (gotData) => this.router.navigate(['/start']) );
  }
}