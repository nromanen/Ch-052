import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { AppComponent } from '../app.component';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'



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

    logout() {
        localStorage.removeItem("access_token");
        localStorage.removeItem("expires_in");
        localStorage.removeItem("user_name");
    }

    login(params:RegisterViewModel): Observable<Token> { 

        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('Username', params.Username);
        urlSearchParams.append('Password', params.Password);
        urlSearchParams.append('grant_type', params.grant_type);
        let body = urlSearchParams.toString()

        return this.http.post(this.advertisementsLoginUrl, body).map(res => { return <Token> res.json();});
                                                                                            //    return this.http.post(this.advertisementsLoginUrl, body).toPromise().then(response => {this.token = response.json() as Token; 
                                                                                            //    localStorage.setItem('access_token', this.token.access_token);    
                                                                                            //    localStorage.setItem('expires_in', this.token.expires_in.toString());  
                                                                                            //    localStorage.setItem('user_name', this.token.userName);  
                                                                                            //    this.status = response.status;} ).catch(this.handleError);

    } 

    isLoggedin() {
        // if (tokenNotExpired())
        //     return true;
        // else
        //     return false;
    }

    getToken():Token{
        return this.token;
    }

    getStatus():number{
        return this.status;
    }



}

