import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement'
import { Headers, HttpModule, Http, Response, RequestOptions } from '@angular/http';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class CreateAdvService {
    constructor(private http: Http) { }

    createAdv(param: Advertisement): Promise<any> {

        return this.http
            .get('api/AspNetUsers/get/current')
            .toPromise()
            .then(response => {
                console.log('response: ', response);
                param.ApplicationUserId = response.json() as string;
                this.http
            .post('api/advertisement/add', param)
            .toPromise()
            .then()
            .catch();
            });

        
    }
    getCategory(): Promise<any> {
        return this.http
            .get('api/Category/get')
            .toPromise()
            .then()
            .catch();
    }
    getType(): Promise<any> {
        return this.http
            .get('api/Type/get')
            .toPromise()
            .then()
            .catch();
    }
}