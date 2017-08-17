import { Injectable, Component } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Component({
      providers:[LoginService]
 })
    
@Injectable()
export class AdvertisementCurrentService{
constructor(private http: Http, private loginService: LoginService) { }

    getCurrentAdvertisements(): Promise<string[]> 
    { 
        let advertisementsCurrentUrl = 'https://localhost:44384/api/Advertisement/get/current';
        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        
        headers.append('Authorization', `Bearer ${authToken}`);

        let options = new RequestOptions({ headers: headers });
        return this.http.get(advertisementsCurrentUrl, options).toPromise().then(response => response.json() as string []).catch(this.handleError);
    } 

    deleteCurrentAdv(param: any): Promise<any> 
    {
        let advDeleteUrl = 'https://localhost:44384/api/Advertisement/delete/' + param.Id;
        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

        return this.http
        .delete(advDeleteUrl, options)
        .toPromise()
        .then()
        .catch(this.handleError);
    }
    
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}