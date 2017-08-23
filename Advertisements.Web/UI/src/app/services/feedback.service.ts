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



    getFeedbacks(id : number) { 
        let feedbacksUrl = 'feedback/getByAdvertisement' + "/" + "1";
        return this.http.get(feedbacksUrl).toPromise().then(response => response.json() as string []).catch(this.handleError);
    } 

    postFeedback(param: any): Promise<any> {

        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

    return this.http
        .post('feedback/add', param, options)
        .toPromise()
        .then()
        .catch();
    } 

    updateFeedback(param: any): Promise<any> {

        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

    return this.http
        .put('feedback/edit', param, options)
        .toPromise()
        .then()
        .catch();
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}