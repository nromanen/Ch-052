import { Injectable } from '@angular/core';

import { Feedback } from '../models/feedback';
import {Headers, HttpModule, Http, Response, RequestOptions} from '@angular/http'; 

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';

import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class FeedbackService{
constructor(private http: Http, private loginService: LoginService) { }

    getFeedbacks(id : number) { 

        return this.http
            .get('api/feedback/getByAdvertisement' + "/" + "4")
            .toPromise()
            .then(response => response.json() as string [])
            .catch(this.handleError);
    } 

    postFeedback(param: any): Promise<any> {

        return this.http
            .post('api/Feedback/add', param)
            .toPromise()
            .then()
            .catch();
    } 

    updateFeedback(param: any): Promise<any> {

        return this.http
            .put('api/feedback/edit', param)
            .toPromise()
            .then()
            .catch();
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}