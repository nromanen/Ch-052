import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class AdvertisementCurrentService{
constructor(private http: Http, private loginService: LoginService) { }


    private advertisementsCurrentUrl = 'https://localhost:44384/api/Adv/get/current';

    getCurrentAdvertisements(): Promise<string[]> { 
        
        console.log(this.loginService.getToken());
        let authToken = this.loginService.getToken().access_token;
        let headers = new Headers();
        
        headers.append('Authorization', `Bearer ${authToken}`);

        let options = new RequestOptions({ headers: headers });
        return this.http.get(this.advertisementsCurrentUrl, options).toPromise().then(response => response.json() as string []).catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}