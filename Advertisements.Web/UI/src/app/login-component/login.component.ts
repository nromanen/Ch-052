import { Component, EventEmitter, Input, Output  } from '@angular/core';
import { Location } from '@angular/common';
import { Router } from '@angular/router';

import { LoginService } from '../services/login.service';
import { ComcomService } from '../services/comcom.service'


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
  
constructor(private loginService: LoginService,
            private comcomService: ComcomService,
            private location: Location,
            private router: Router
            ) {}

@Input() registerViewModel: RegisterViewModel = new RegisterViewModel;    

token:Token;

  goClick(): void {
    
    
    this.registerViewModel.Username = this.registerViewModel.Email;
    this.registerViewModel.grant_type = 'password';

    this.loginService.login(this.registerViewModel).subscribe(response => {this.token = response as Token;                                                                             
                                                                                  localStorage.setItem('access_token', this.token.access_token);    
                                                                                  localStorage.setItem('expires_in', this.token.expires_in.toString());  
                                                                                  localStorage.setItem('user_name', this.token.userName); 
                                                                                  this.sendToken(this.token);                                                                                  
                                                                                  this.router.navigate(['/start']);
                                                                                  }, 
                                                                                  err => console.log('Something went wrong!')  );
  }

  public sendToken(token: Token): void { 
    this.loginService.getRole().then(res => {console.log(res);localStorage.setItem('role', res[0]);});
    
    this.comcomService.sendToken(token);
}

}