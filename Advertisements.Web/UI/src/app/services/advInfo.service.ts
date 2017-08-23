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
export class AdvInfoService {
    constructor(private http: Http, private loginService: LoginService) { }

    getAdvertisement(param: any): Promise<Advertisement> {
        let getAdvEdit = 'https://localhost:44384/api/Advertisement/get/' + param;

        return this.http.get(getAdvEdit).toPromise().then(response => response.json() as Advertisement).catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}