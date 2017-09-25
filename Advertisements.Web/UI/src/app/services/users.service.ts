import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';
import 'rxjs/add/operator/toPromise';
import { Token } from "../models/token";
import { Resource } from "../models/resource";
import { AdvertisementsUserModel } from "../models/AdvertisementsUserModel";
import { AspNetUserModel } from "../models/AspNetUserModel";
import { DomSanitizer } from "@angular/platform-browser";
@Injectable()

export class UsersService {
    private GetUserAvatarUrl;
    private GetAdvertisementsUserUrl: string;
    private GetAspNetUserUrl: string;
    private MyHttp: Http;


    public constructor(http: Http) {
        this.GetUserAvatarUrl = "/api/Account/getavatar/";
        this.GetAdvertisementsUserUrl = "/api/AdvertisementUsers/get";
        this.GetAspNetUserUrl = "/api/AspNetUsers/get/";
        this.MyHttp = http;
    }

    public GetAdvertisementsUsers(): Promise<AdvertisementsUserModel[]> {
        return this.MyHttp.get(this.GetAdvertisementsUserUrl).toPromise().
            then(result => result.json() as AdvertisementsUserModel[]).catch(this.ShowError);
    }

    public GetAspNetUser(id: string): Promise<AspNetUserModel> {
        return this.MyHttp.get(this.GetAspNetUserUrl + id).toPromise().
            then(result => result.json() as AspNetUserModel).catch(this.ShowError);
    }

    public GetUserAvatar(id: string): Promise<string> {
        return this.MyHttp.get(this.GetUserAvatarUrl + id)
            .toPromise()
            .then(result => result.json() as string).catch(this.ShowError);
    }


    private ShowError(error: void): Promise<any> {
        console.error("An error occurred", error);
        return Promise.reject(error);
    }
}