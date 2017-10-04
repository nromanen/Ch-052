import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";
import { Resource } from "../models/resource";


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";
import { Observable } from "rxjs/Observable";
import { Router } from "@angular/router";

@Injectable()
export class AdvertisementService {
    constructor(private http: Http, private loginService: LoginService, private router: Router) { }

    private advertisements: Advertisement[];
    private advertisement: Advertisement;

    getAds(pageSize: number, page: number): Promise<Advertisement[]> {
        console.log(page + " " + pageSize);
        let advertisementsLoginUrl = '/api/Advertisement/takepage';
        let body = {
            PageSize: pageSize,
            Page: page
        }
        
        let header = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: header });        
        

        return this.http.post(advertisementsLoginUrl,body,options)
            .toPromise()
            .then(response => {
                this.advertisements = response.json() as Advertisement[];

                this.advertisements.forEach(element => {
                    if (element.Resources[0].Url == null && element.Resources.length > 0)
                        element.Resources[0].Url = "../../../assets/images/noPhoto.png"
                    if (element.Resources.length == 0)
                        element.Resources.push(new Resource(0, '../../../assets/images/noPhoto.png', 0));
                });

                return this.advertisements;
            })
            .catch(this.handleError);
    }

    getAdsCount(): Promise<number>
    {
        let url: string = "/api/Advertisement/getadvcount";
        let count: number = 0;
        return this.http.get(url)
        .toPromise()
        .then(response =>{
            count = response.json() as number;

            return count;
        })
        .catch(this.handleError);
    }

    getAdsByUser(id: string): Promise<Advertisement[]> {
        let getAdvertsByUserUrl = "/api/Advertisement/findbyuser/";

        return this.http.get(getAdvertsByUserUrl + id)
            .toPromise()
            .then(response => {
                this.advertisements = response.json() as Advertisement[];

                this.advertisements.forEach(element => {
                    if (element.Resources[0].Url == null && element.Resources.length > 0)
                        element.Resources[0].Url = "../../../assets/images/noPhoto.png"
                    if (element.Resources.length == 0)
                        element.Resources.push(new Resource(0, '../../../assets/images/noPhoto.png', 0));
                });

                return this.advertisements;
            })
            .catch(this.handleError);

    }

    getAdv(param: any): Promise<Advertisement> {
        let getAdvEdit = 'api/Advertisement/get/' + param;

        return this.http.get(getAdvEdit).toPromise().then(response => {
            this.advertisement = response.json() as Advertisement;
            if (this.advertisement.Resources[0].Url == null && this.advertisement.Resources.length > 0)
                this.advertisement.Resources[0].Url = "../../../assets/images/noPhoto.png"
            if (this.advertisement.Resources.length == 0)
                this.advertisement.Resources.push(new Resource(0, '../../../assets/images/noPhoto.png', 0));


            return this.advertisement;
        }).catch(this.handleError);
    }

    getLoggedUserAds(): Promise<Advertisement[]> {
        return this.http.get('api/Advertisement/get/current')
            .toPromise()
            .then(response => {
                this.advertisements = response.json() as Advertisement[];

                this.advertisements.forEach(element => {
                    if (element.Resources[0].Url == null && element.Resources.length > 0)
                        element.Resources[0].Url = "../../../assets/images/noPhoto.png"
                    if (element.Resources.length == 0)
                        element.Resources.push(new Resource(0, '../../../assets/images/noPhoto.png', 0));
                });

                return this.advertisements;
            })
            .catch(this.handleError);
    }

    deleteLoggedUserAds(param: any): Promise<any> {
        return this.http.delete('api/Advertisement/delete/' + param.Id)
            .toPromise()
            .then()
    }
    editLoggedUserAdv(param: Advertisement): Observable<any> {
        let advEditUrl = 'api/Advertisement/edit/';
        return this.http.put(advEditUrl, param).do(r => {
            if (r.status == 200 || r.status == 204)
                this.router.navigate(['/start']);
        }).map(r => r).catch(this.handleError);
    }
    createAdv(param: Advertisement, resource: Resource[]): Observable<any> {
        param.Resources = [];

        for (let i = 0; i < resource.length; i++) {
            param.Resources.push(resource[i]);
        }

        return this.http
            .get('api/AspNetUsers/get/current')
            .map(response => {
                param.ApplicationUserId = response.json() as string;
                this.http
                    .post('api/Advertisement/add', param).toPromise().then(r => {
                        if (r.status == 200 || r.status == 204)
                            this.router.navigate(['/start']);
                    })
            });
    }
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}