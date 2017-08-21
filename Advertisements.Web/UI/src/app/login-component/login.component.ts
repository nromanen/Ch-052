import { Component, Input, EventEmitter  } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

import { LoginService } from '../services/login.service';


import { RegisterViewModel } from '../models/register.view.model';

import 'rxjs/add/operator/switchMap';

import { Token } from "../models/token";

@Component({
    moduleId: module.id.toString(),
  selector: 'advertisement-login',
  templateUrl: `./login.component.html`,
  styleUrls: [`./login.component.css`]
})

export class LoginComponent {
  token:Token;
constructor(
                private loginService: LoginService,
                private location: Location,
                private router: Router
            ) {}
           

@Input() registerViewModel: RegisterViewModel = new RegisterViewModel;

  goClick(): void {
    
    this.registerViewModel.Username = this.registerViewModel.Email;
    this.registerViewModel.grant_type = 'password';

    this.loginService.login(this.registerViewModel).subscribe(response => {this.token = response as Token;                                                                             
                                                                                  localStorage.setItem('access_token', this.token.access_token);    
                                                                                  localStorage.setItem('expires_in', this.token.expires_in.toString());  
                                                                                  localStorage.setItem('user_name', this.token.userName); 
                                                                                  this.router.navigate(['/start']);}, 
                                                                                  err => console.log('Something went wrong!')  );
  }
}