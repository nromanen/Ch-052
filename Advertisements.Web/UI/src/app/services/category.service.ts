import { Injectable } from '@angular/core';

import { Category } from '../models/category';
import { Headers, HttpModule, Http, Response, RequestOptions } from '@angular/http';

import { LoginService } from '../services/login.service';

import { Token } from "../models/token";

import 'rxjs/add/operator/toPromise';

import { RegisterViewModel } from "../models/register.view.model";

@Injectable()
export class CategoryService {
    constructor(private http: Http, private loginService: LoginService) { }

    private categoryUrl = "https://localhost:44384/api/category/";

    getCategories(): Promise<Category[]> {

        let headers = new Headers();

        var token = localStorage.getItem("access_token");
        headers.append('Authorization', `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.categoryUrl + "get", options).
            toPromise().
            then(response => { response.json() as Category[]; return response.json() as Category[]; }).
            catch(this.handleError);
    }

    getCategory(id: number): Promise<Category> {
        let headers = new Headers();

        var token = localStorage.getItem("access_token");
        headers.append('Authorization', `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.categoryUrl + "get/" + id, options).
            toPromise().
            then(response => response.json() as Category).
            catch(this.handleError);
    }

    deleteCategory(category: Category): Promise<Category[]> {
        let headers = new Headers();

        var token = localStorage.getItem("access_token");
        headers.append('Authorization', `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.delete(this.categoryUrl + "delete/" + category.Id, options).
            toPromise().
            then(response => { response.json() as Category[] }).
            catch(this.handleError);
    }

    updateCategory(category: Category): Promise<Category[]> {
        let headers = new Headers();

        var token = localStorage.getItem("access_token");
        headers.append('Authorization', `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this.categoryUrl + "edit", category, options).
            toPromise().
            then(response => { response.json() as Category[] }).
            catch(this.handleError);
    }

    createCategory(category: Category): Promise<Category[]> {
        let headers = new Headers();

        var token = localStorage.getItem("access_token");
        headers.append('Authorization', `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.categoryUrl + "add", category, options).
            toPromise().
            then(response => { response.json() as Category[] }).
            catch(this.handleError);
    }

    private handleError(error: void): Promise<any> {
        console.error("An error occurred", error);
        return Promise.reject(error);
    }
}