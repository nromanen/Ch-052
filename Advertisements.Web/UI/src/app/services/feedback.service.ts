import { Injectable } from '@angular/core';

import { Feedback } from '../models/feedback';
import {Headers, HttpModule, Http, Response, RequestOptions} from '@angular/http'; 

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class FeedbackService{
constructor(private http: Http, private loginService: LoginService) { }


    private feedbacksUrl = 'https://localhost:44384/api/feedback/get';

    getFeedbacks() { 
        return this.http.get(this.feedbacksUrl).toPromise().then(response => response.json() as string []).catch(this.handleError);
    } 

    postFeedback(param: any): Promise<any> {

        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

    return this.http
        .post('https://localhost:44384/api/feedback/add', param, options)
        .toPromise()
        .then()
        .catch(this.handleError);
    } 

    updateFeedback(param: any): Promise<any> {
    return this.http
        .put('https://localhost:44384/api/feedback/edit', param)
        .toPromise()
        .then()
        .catch(this.handleError);
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}