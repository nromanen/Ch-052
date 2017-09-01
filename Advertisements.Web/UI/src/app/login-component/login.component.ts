<<<<<<< HEAD
import { Component, Input } from '@angular/core';
=======
import { Component, EventEmitter, Input, Output  } from '@angular/core';
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
import { Location } from '@angular/common';
import { Router } from '@angular/router';

import { LoginService } from '../services/login.service';
<<<<<<< HEAD
=======
import { ComcomService } from '../services/comcom.service'

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

import { RegisterViewModel } from '../models/register.view.model';

import 'rxjs/add/operator/switchMap';

import { Token } from "../models/token";

@Component({
<<<<<<< HEAD
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
=======
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
                                                                                  } );
  }

  public sendToken(token: Token): void { 
    this.loginService.getRole().then(res => {
      localStorage.setItem('role', res[0]);
      this.comcomService.sendObservableRole(res[0]);
    });
    
    this.comcomService.sendToken(token);
    this.comcomService.sendObservableToken(token);   
}

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
}