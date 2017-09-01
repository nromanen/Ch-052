import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";
import { Resource } from "../models/resource";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class AdvertisementService{
constructor(private http: Http, private loginService: LoginService) { }


    private advertisementsLoginUrl = '/api/Advertisement/get';
    private advertisements: Advertisement[];

    getAdvertisements(): Promise<Advertisement[]> { 

        return this.http.get(this.advertisementsLoginUrl)
                        .toPromise()
                        .then(response => {
                            this.advertisements = response.json() as Advertisement []; 

                            this.advertisements.forEach(element => {
                                if (element.Resources[0].Url == null && element.Resources.length > 0)
                                    element.Resources[0].Url = "../../../assets/images/noPhoto.png"
                                if (element.Resources.length == 0)
                                    element.Resources.push (new Resource(0, '../../../assets/images/noPhoto.png', 0 ));
                            });

                            return this.advertisements; })
                        .catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}