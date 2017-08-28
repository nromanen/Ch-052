import { Injectable, Component } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';

@Component({
    providers: [LoginService]
})

@Injectable()
export class EditAdvService {
    constructor(private http: Http, private loginService: LoginService) { }

    getAdvertisement(param: any): Promise<Advertisement> {
        let getAdvEdit = 'api/Advertisement/get/' + param;
        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();

        headers.append('Authorization', `Bearer ${authToken}`);

        let options = new RequestOptions({ headers: headers });

        return this.http.get(getAdvEdit, options).toPromise().then(response => response.json() as Advertisement).catch(this.handleError);
    }

    editAdv(param: Advertisement): Promise<any> {
        let advEditUrl = 'api/Advertisement/edit/';
        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();

        headers.append('Authorization', `Bearer ${authToken}`);

        let options = new RequestOptions({ headers: headers });

        return this.http.put(advEditUrl, param, options).toPromise().then().catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
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
            .get('api/AdvertisementType/get')
            .toPromise()
            .then()
            .catch();
    }
}