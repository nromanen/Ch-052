import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Token } from "../models/token";

@Injectable()
export class LoginService{
    constructor(private http: Http) { }
    private advertisementsLoginUrl = 'https://localhost:44384/Token';
    token:Token;
    status:number;

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

        return this.http.post(this.advertisementsLoginUrl, body).toPromise().then(response => {this.token = response.json() as Token; 
                                                                                               console.log(this.token); 
                                                                                               this.status = response.status;} ).catch(this.handleError);
    } 

    getToken():Token{
        return this.token;
    }

    getStatus():number{
        return this.status;
    }

}

