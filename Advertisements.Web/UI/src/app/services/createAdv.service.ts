import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement'
import { Headers, HttpModule, Http, Response, RequestOptions } from '@angular/http';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Observable } from "rxjs/Observable";
import { Resource } from "../models/resource";

@Injectable()
export class CreateAdvService {
    constructor(private http: Http) { }

    createAdv(param: Advertisement, resource: Resource): Observable<any> {
        param.Resources = []; 
        param.Resources.push(resource);
        return this.http
            .get('api/AspNetUsers/get/current')
            .map(response => {
                param.ApplicationUserId = response.json() as string;
                this.http
                    .post('api/advertisement/add', param).toPromise().then()
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