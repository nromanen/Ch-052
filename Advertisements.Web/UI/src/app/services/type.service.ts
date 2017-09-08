import { Injectable } from "@angular/core";

import { Type } from "../models/type";

import { Headers, HttpModule, Http, Response, RequestOptions } from "@angular/http";

import { LoginService } from "../services/login.service";

import { RegisterViewModel } from "../models/register.view.model";

import 'rxjs/add/operator/toPromise';

@Injectable()
export class TypeService {
    constructor(private http: Http, private loginService: LoginService) { }
    private typeUrl = "/api/type/";

    types: Type[];
    type: Type;

    getTypes(): Promise<Type[]> {

        return this.http.get(this.typeUrl + "get").
            toPromise().
            then(response => { this.types = response.json() as Type[];
            return this.types }).
            catch(this.handleError);
    }

    getType(id): Promise<Type> {


        return this.http.get(this.typeUrl + "get/" + id).
            toPromise().
            then(response => { response.json() as Type }).
            catch(this.handleError);
    }

    deleteType(type: Type): Promise<Type> {


        return this.http.delete(this.typeUrl + "delete/" + type.Id).
            toPromise().
            then(response => { response.json() as Type[]; return response.json() as Type[]; }).
            catch(this.handleError);

    }

    createType(type: Type): Promise<Type[]> {

        return this.http.post(this.typeUrl + "add", type).
            toPromise().
            then(response => { response.json() as Type[] }).
            catch(this.handleError);
    }

    updateType(type: Type): Promise<Type[]> {

        return this.http.put(this.typeUrl + "edit", type).
            toPromise().
            then(response => { response.json() as Type[] }).
            catch(this.handleError);

    }

    private handleError(error: void): Promise<any> {
        console.error("An error occurred", error);
        return Promise.reject(error);
    }
}