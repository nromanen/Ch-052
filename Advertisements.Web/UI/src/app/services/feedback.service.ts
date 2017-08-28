import { Injectable } from '@angular/core';

import { Feedback } from '../models/feedback';
import { Headers, HttpModule, Http, Response, RequestOptions } from '@angular/http';

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class FeedbackService {
    constructor(private http: Http, private loginService: LoginService) { }



    getFeedbacks(id: number) {
        let feedbacksUrl = 'https://localhost:44384/api/feedback/getByAdvertisement/' + id;
        return this.http.get(feedbacksUrl).toPromise().then(response => response.json() as string[]).catch(this.handleError);
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
            .catch();
    }

    updateFeedback(param: any): Promise<any> {

        let authToken = localStorage.getItem("access_token");
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new RequestOptions({ headers: headers });

        return this.http
            .put('https://localhost:44384/api/feedback/edit', param, options)
            .toPromise()
            .then()
            .catch();
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}