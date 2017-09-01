import { Injectable } from '@angular/core';

import { Headers, Http, RequestOptions } from "@angular/http";

import { AppComponent } from '../app.component';

import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/toPromise';
import { ComcomService } from '../services/comcom.service';
import { Notification } from "../models/notification";

@Injectable()

export class ConfirmEmailService
{
    private MyHttpClient: Http;
    private ConfirmEmailUrl: string;

    public constructor(http: Http, private comservice: ComcomService)
    {
        this.MyHttpClient = http;
        this.ConfirmEmailUrl = "/api/Account/ConfirmEmail"
    }

    public SendRequest(token: string,email: string)
    {
        let body = {Token:token, Email:email};
        let header = new Headers({'Content-Type': 'application/json'});
        let options = new RequestOptions({headers:header});

        return this.MyHttpClient.post(this.ConfirmEmailUrl,body,options)       
        .subscribe(resp=> this.TakeResponse(resp.json()));
    }
    
    private TakeResponse(response: string)
    {
        alert(response);
        window.location.replace("/start");
    }
}