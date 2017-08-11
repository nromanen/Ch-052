import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Token } from "../models/token";

@Injectable()
export class LoginService{
    constructor(private http: Http) { }
    private advertisementsLoginUrl = 'https://localhost:44335/Token';
    token:Token;
    status:number;
    // getAdvertisements(): Promise<Advertisement[]> { 
    //     return this.http.get(this.advertisementsLoginUrl).toPromise().then(response => response.json() as Advertisement []).catch(this.handleError);
    // } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }

    login(params:RegisterViewModel): Promise<Token> { 

        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('Username', params.Username);
        urlSearchParams.append('Password', params.Password);
        urlSearchParams.append('grant_type', params.grant_type);
        let body = urlSearchParams.toString()

        return this.http.post(this.advertisementsLoginUrl, body).toPromise().then(response => {this.token = response.json() as Token; this.status = response.status;}).catch(this.handleError);
    } 

    getToken():Token{
        return this.token;
    }

    getStatus():number{
        return this.status;
    }

}

