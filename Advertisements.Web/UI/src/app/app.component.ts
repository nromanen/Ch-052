import { Component, OnInit } from '@angular/core';
import {Http} from "@angular/http";
import { Advertisement } from './models/advertisement';

import { LoginService } from './services/login.service';

import { Token } from './models/token';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [],


})
export class AppComponent implements OnInit {

  access_token: string;
  constructor(private router: Router, private loginService: LoginService) { 
        this.access_token = localStorage.getItem('access_token');
    console.log('outside');
    //console.log(this.access_token);
    if (this.access_token !== null) {
      console.log('inside');
    }
  }


  ngOnInit(): void {

  }

  title: string = 'Advertisements';
  loginbuttontext: string = 'Log in';
  token: Token;
}
