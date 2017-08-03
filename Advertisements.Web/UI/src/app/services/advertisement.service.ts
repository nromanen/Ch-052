import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http } from "@angular/http";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class AdvertisementService{
constructor(private http: Http) { }
    private advertisementsUrl = 'http://localhost:8080/api/values';

    getAdvertisements(): Promise<Advertisement[]> { 
        return this.http.get(this.advertisementsUrl).toPromise().then(response => response.json() as Advertisement []).catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }
}