import { Injectable } from "@angular/core";

import { Type } from "../models/type";

import { Headers, HttpModule, Http, Response, RequestOptions } from "@angular/http";

import { LoginService } from "../services/login.service";

import { RegisterViewModel } from "../models/register.view.model";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class TypeService {
    constructor(private http: Http, private loginService: LoginService) { }
    private typeUrl = "https://localhost:44384/api/Type/";

    getTypes(): Promise<Type[]> {
        let headers = new Headers();
        var token = localStorage.getItem("access_token");
        headers.append("Authorization", `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.typeUrl + "get", options).
            toPromise().
            then(response => { response.json() as Type[]; console.log("Service", response.json() as Type[]); return response.json() as Type[]; }).
            catch(this.handleError);
    }

    getType(id: number): Promise<Type> {
        let headers = new Headers();
        var token = localStorage.getItem("access_token");
        headers.append("Authorization", `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.get(this.typeUrl + "get/" + id, options).
            toPromise().
            then(response => { response.json() as Type }).
            catch(this.handleError);
    }

    deleteType(type: Type): Promise<Type> {
        let headers = new Headers();
        var token = localStorage.getItem("access_token");
        headers.append("Authorization", `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.delete(this.typeUrl + "delete/" + type.Id, options).
            toPromise().
            then(response => { response.json() as Type[]; console.log("Service", response.json() as Type[]); return response.json() as Type[]; }).
            catch(this.handleError);

    }

    createType(type: Type): Promise<Type[]> {
        let headers = new Headers();
        var token = localStorage.getItem("access_token");
        headers.append("Authorization", `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.typeUrl + "add", type, options).
            toPromise().
            then(response => { response.json() as Type[] }).
            catch(this.handleError);
    }

    updateType(type: Type): Promise<Type[]> {
        let headers = new Headers();
        var token = localStorage.getItem("access_token");
        headers.append("Authorization", `Bearer ${token}`);
        let options = new RequestOptions({ headers: headers });

        return this.http.put(this.typeUrl + "edit", type, options).
            toPromise().
            then(response => { response.json() as Type[] }).
            catch(this.handleError);

    }

    private handleError(error: void): Promise<any> {
        console.error("An error occurred", error);
        return Promise.reject(error);
    }
}