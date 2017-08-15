import { Component, OnInit } from '@angular/core';
import { Advertisement } from './models/advertisement';

import { LoginService } from './services/login.service';

import { Token } from './models/token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private router: Router, private loginService: LoginService) { }

  title: string = 'Advertisements';
  loginbuttontext: string = 'Log in';
  token: Token;
}
