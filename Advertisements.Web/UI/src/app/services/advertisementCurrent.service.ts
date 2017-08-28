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
        return this.http.get('https://localhost:44384/api/Advertisement/get/current')
                        .toPromise()
                        .then(response => response.json() as string [])
                        .catch(this.handleError);
    } 

    deleteCurrentAdv(param: any): Promise<any> 
    {
        return this.http.delete('https://localhost:44384/api/Advertisement/delete/' + param.Id)
                        .toPromise()
                        .then()
                        .catch(this.handleError);
    }
    
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}