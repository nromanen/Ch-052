import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";
import { Resource } from "../models/resource";

@Injectable()

export class SearchService
{
    private SearchAdvertisements: Advertisement[];
    private GetAdvertsUrl: string;
    public keyword: string;
    public constructor(private MyHttp: Http)
    {
        this.GetAdvertsUrl = "/api/Advertisement/find/";
    }

    public Search(): Promise<Advertisement[]>
    {
         return this.MyHttp.get(this.GetAdvertsUrl + this.keyword).
            toPromise().
            then(response=>{
                this.SearchAdvertisements = response.json() as Advertisement[];
                this.SearchAdvertisements.forEach(element => {
                    if (element.Resources.length == 0)
                        element.Resources.push (new Resource(0, '../../../assets/images/noPhoto.png', 0 ));                 
                });
                return this.SearchAdvertisements;
            }
            ).catch(this.handleError);
         
    }
    
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }  
}