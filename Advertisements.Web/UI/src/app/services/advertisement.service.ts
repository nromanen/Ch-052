import { Injectable } from '@angular/core';

import { Advertisement } from '../models/advertisement';
import { Headers, Http, RequestOptions } from "@angular/http";

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";
<<<<<<< HEAD
=======
import { Resource } from "../models/resource";
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d


import 'rxjs/add/operator/toPromise';
import { RegisterViewModel } from "../models/register.view.model";

<<<<<<< HEAD

// @Component({
//       providers:[LoginService]
// })
=======
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
@Injectable()
export class AdvertisementService{
constructor(private http: Http, private loginService: LoginService) { }


<<<<<<< HEAD
    private advertisementsLoginUrl = 'https://localhost:44335/api/values/get';

    getAdvertisements(): Promise<string[]> { 
        
        console.log(this.loginService.getToken());
        let authToken = this.loginService.getToken().access_token;
        let headers = new Headers();
        
        headers.append('Authorization', `Bearer ${authToken}`);

        let options = new RequestOptions({ headers: headers });
        return this.http.get(this.advertisementsLoginUrl, options).toPromise().then(response => response.json() as string []).catch(this.handleError);
=======
    private advertisementsLoginUrl = '/api/Advertisement/get';
    private advertisements: Advertisement[];

    getAdvertisements(): Promise<Advertisement[]> { 

        return this.http.get(this.advertisementsLoginUrl)
                        .toPromise()
                        .then(response => {
                            this.advertisements = response.json() as Advertisement []; 

                            this.advertisements.forEach(element => {
                                if (element.Resources[0].Url == null && element.Resources.length > 0)
                                    element.Resources[0].Url = "../../../assets/images/noPhoto.png"
                                if (element.Resources.length == 0)
                                    element.Resources.push (new Resource(0, '../../../assets/images/noPhoto.png', 0 ));
                            });

                            return this.advertisements; })
                        .catch(this.handleError);
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    } 

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }    
}