import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { AppComponent } from '../app.component';

import { Observable } from 'rxjs/Observable';
import { UserRegisterModel } from '../models/UserRegisterModel'

@Injectable()
export class RestorePasswordService
{
    private MyHttpService: Http;
    private CheckTokenAndEmailUrl: string;
    private RestorePasswordUrl:string;
    private Email:string = null;
    private Token:string = null;

    public constructor(http: Http)
    {
        this.MyHttpService = http;
        this.CheckTokenAndEmailUrl = "/api/Account/CheckPassRestoreData";
        this.RestorePasswordUrl = "api/Account/RestorePassword";
    }

    public CheckEmailAndToken(email: string, token: string): Observable<Response>
    {
        this.Email = email;
        this.Token = token;
        let body = {Email:this.Email, Token: this.Token};
        let header = new Headers({'Content-Type': 'application/json'});
        let options = new RequestOptions({headers: header});

        return this.MyHttpService.post(this.CheckTokenAndEmailUrl,body,options).map((result)=>result.json());
    }
    public ResetPassword(password: string): Observable<Response>
    {
        if(this.Email == null || this.Token == null)
            return null;

        let body = {Email: this.Email,EmailToken: this.Token, NewPassword: password};
        let header = new Headers({'Content-Type': 'application/json'});
        let options = new RequestOptions({headers: header});

        return this.MyHttpService.post(this.RestorePasswordUrl,body,options).map((result)=>result.json());
    }
}