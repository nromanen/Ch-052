import { Injectable } from '@angular/core';

import { Category } from '../models/category';
import {Headers, HttpModule, Http, Response, RequestOptions} from '@angular/http'; 

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';

import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class CategoryService{
constructor(private http: Http, private loginService: LoginService) { }

private categoryUrl = "https://localhost:44384/api/Category/";

    getCategories(): Promise<Category[]> { 
        return this.http.get(this.categoryUrl + "get").
        toPromise().
        then(response => { response.json() as Category[]; console.log("Service", response.json() as Category[]); return response.json() as Category[]; }).
        catch(this.handleError);
    } 

    private handleError(error: void): Promise<any> {
        console.error("An error occurred", error); 
        return Promise.reject(error);
    }    
}