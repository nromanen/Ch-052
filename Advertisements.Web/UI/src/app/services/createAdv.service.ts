import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement'
import {Headers, HttpModule, Http, Response, RequestOptions} from '@angular/http'; 

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class CreateAdvService{
constructor(private http: Http, private loginService: LoginService) { }

    createAdv(param: any): Promise<any> {

        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

    return this.http
        .post('api/advertisement/add', param, options)
        .toPromise()
        .then()
        .catch();
    } 
}