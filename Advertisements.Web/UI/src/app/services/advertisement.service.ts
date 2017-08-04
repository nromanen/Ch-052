import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Login } from "../models/login";

@Injectable()
export class AdvertisementService{
constructor(private http: Http) { }
    private advertisementsLginUrl = 'http://localhost:8080/Token';

    getAdvertisements(): Promise<Advertisement[]> { 
        return this.http.get(this.advertisementsLginUrl).toPromise().then(response => response.json() as Advertisement []).catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }

    login(params:RegisterViewModel): Promise<Login> { 
        // let headers = new Headers({ 'Content-Type': 'application/json' });
        // let options = new RequestOptions({ headers: headers });
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' });
        let options = new RequestOptions( {headers: headers });
        return this.http.post(this.advertisementsLginUrl, params, options).toPromise().then(response => response.json() as Login).catch(this.handleError);
    } 

}