import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

<<<<<<< HEAD
=======
import { AppComponent } from '../app.component';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'


>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Token } from "../models/token";

<<<<<<< HEAD
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
=======
import {ComcomService} from './comcom.service';

@Injectable()
export class LoginService {
    constructor(private http: Http, private comcomService:ComcomService) { }
    private advertisementsLoginUrl = '/Token';
    token: Token;
    status: number;

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }

    login(params: RegisterViewModel): Observable<Token> {
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('Username', params.Username);
        urlSearchParams.append('Password', params.Password);
        urlSearchParams.append('grant_type', params.grant_type);
<<<<<<< HEAD
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

=======
        let body = urlSearchParams.toString();

        return this.http.post(this.advertisementsLoginUrl, body).map(res => { return <Token>res.json(); });
        //    return this.http.post(this.advertisementsLoginUrl, body).toPromise().then(response => {this.token = response.json() as Token; 
        //    localStorage.setItem('access_token', this.token.access_token);    
        //    localStorage.setItem('expires_in', this.token.expires_in.toString());  
        //    localStorage.setItem('user_name', this.token.userName);  
        //    this.status = response.status;} ).catch(this.handleError);

    }

    logout(): Observable<any> {
        
        this.comcomService.clearObservableToken();
        
        
        return this.http.post('/api/account/logout',null)
            .map(res => {
                localStorage.clear();
            });
    }

    getRole():Promise<string[]>{
        return this.http.get('/api/account/roles').toPromise().then(res => {
            
            return <string[]> res.json(); 
        }).catch(this.handleError);
    }

    isLoggedin(): void {
        // if (tokenNotExpired())
        //     return true;
        // else
        //     return false;
    }

    getToken(): Token {
        return this.token;
    }

    getStatus(): number {
        return this.status;
    }
}
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
