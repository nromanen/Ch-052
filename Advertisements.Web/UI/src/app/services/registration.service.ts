import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { AppComponent } from '../app.component';

import { Observable } from 'rxjs/Observable';
import { UserRegisterModel } from '../models/UserRegisterModel'
@Injectable()
export class RegistrationService {
    private MyHttpClient: Http;
    private UrlToRegister: string;
    public RegisterModel: UserRegisterModel;
    public base64textString: any;
    public constructor(http: Http) {
        this.MyHttpClient = http;
        this.UrlToRegister = "/api/Account/Register";
    }

    public PostUser(): Observable<Response> {
           
         let requestBody = {
            UserName: this.RegisterModel.Name + " " + this.RegisterModel.Surname,
            Email: this.RegisterModel.Email, Password: this.RegisterModel.Password,
            Avatar: this.base64textString
        };
        let header = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: header });

        return this.MyHttpClient.post(this.UrlToRegister, requestBody,options).map((result) => result.json());
    }
    encodeFile(file:File, reader: FileReader)
    {
        reader.readAsDataURL(file);
    }
}