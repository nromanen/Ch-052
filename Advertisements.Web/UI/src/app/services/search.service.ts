import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";
import { Resource } from "../models/resource";

@Injectable()

export class SearchService
{
    private advertisements: Advertisement[];
    private GetAdvertsUrl: string;
    public keyword: string;
    public constructor(private MyHttp: Http)
    {
        this.GetAdvertsUrl = "/api/Advertisement/find/";
    }

    public Search(keyword: string): Promise<Advertisement[]>
    {
         return this.MyHttp.get(this.GetAdvertsUrl + keyword)
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
    
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }  
}