import { Injectable, Component, Input } from "@angular/core";
import { ConnectionBackend, RequestOptions, Request, RequestOptionsArgs, Response, Http, Headers } from "@angular/http";
import { Observable } from "rxjs/Rx";
import { environment } from "../environments/environment";
import { Token } from "./models/token";
import { Notification } from "./models/notification";
import { ComcomService } from './services/comcom.service';
import 'rxjs/add/operator/toPromise';


@Injectable()


export class InterceptedHttp extends Http {
    constructor(backend: ConnectionBackend, defaultOptions: RequestOptions, private comservice: ComcomService) {
        super(backend, defaultOptions);
    }



    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);

        return super.get(url, this.getRequestOptionArgs(options))
            .catch((err) => {
                this.notify(err);
                return Observable.throw(err);
            });


    }

    post(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);

        return super.post(url, body, this.getRequestOptionArgs(options))
            .catch((err) => {
                this.notify(err);
                return Observable.throw(err);
            });

    }

    put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);

        return super.put(url, body, this.getRequestOptionArgs(options))
            .catch((err) => {
                this.notify(err);
                return Observable.throw(err);
            });
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        url = this.updateUrl(url);

        return super.delete(url, this.getRequestOptionArgs(options))
            .catch((err) => {
                this.notify(err);
                return Observable.throw(err);
            });
    }

    private updateUrl(req: string) {
        return req;
    }

    private getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {

        var token = localStorage.getItem('access_token');
        let headers = new Headers();
        headers.append('Authorization', `Bearer ${token}`);
        options = new RequestOptions({ headers: headers })
        console.log(options);

        return options;

    }

    private notify(error: Response) {

        let note: Notification = new Notification();

        if (error.status === 401) {
            note.errorMessage = "You need to authorize";
            note.accessDenied = true;

            this.comservice.setNotification(note);
        }

        if (error.status === 403) {
            note.errorMessage = "Access denied";
            note.accessDenied = true;

            this.comservice.setNotification(note);
        }
    }

}