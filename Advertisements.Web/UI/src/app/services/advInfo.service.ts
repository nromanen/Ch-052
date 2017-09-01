import { Injectable, Component} from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';
import { Resource } from "../models/resource";
import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';

@Component({
    providers: [LoginService]
})

@Injectable()
export class AdvInfoService {
    constructor(private http: Http, private loginService: LoginService) { }
    private advertisement: Advertisement;
    getAdvertisement(param: any): Promise<Advertisement> {
        let getAdvEdit = 'api/Advertisement/get/' + param;

        return this.http.get(getAdvEdit).toPromise().then(response => {
            this.advertisement = response.json() as Advertisement; 

                if (this.advertisement.Resources.length == 0)
                    this.advertisement.Resources.push (new Resource(0,'../../../assets/images/noPhoto.png',0));
       

            return this.advertisement; }).catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
}