import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class AdvertisementService{
constructor(private http: Http, private loginService: LoginService) { }


    private advertisementsLoginUrl = 'https://localhost:44384/api/Advertisement/get';

    getAdvertisements(): Promise<Advertisement[]> { 
        
         let headers = new Headers();
         let options = new RequestOptions({ headers: headers });
        return this.http.get(this.advertisementsLoginUrl, options).toPromise().then(response => response.json() as Advertisement []).catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}