import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';

import { Token } from '../models/token'
import { Notification } from "../models/notification";

@Injectable()
export class ComcomService {

    private comcomSubject = new Subject<Token>();

    private token;

    private errorNotification = new Subject<Notification>();

    sendObservableToken(token: Token) {
        this.comcomSubject.next(token);
    }

    sendToken(token: Token) {
        this.token = token;
        console.log(this.token);
    } 

    clearObservableToken() {
        this.comcomSubject.next();
    }

    clearToken() {
        this.token = null;
    } 

    getObservableToken(): Observable<Token> {

        return this.comcomSubject.asObservable();
    }

    loadTokenFromStorage() : void {
        let res : Token = new Token();
        if (localStorage.getItem('access_token'))
        {
            res.access_token = localStorage.getItem('access_token');
            res.expires_in = +localStorage.getItem('expires_in');
            res.userName = localStorage.getItem('user_name');
            this.comcomSubject.next(res);
        }
    }

    getToken(): Token {
        return this.token;
    } 

    setNotification(notification: Notification) {
        this.errorNotification.next(notification);
    }

    clearNotification() {
        this.errorNotification.next();
    }

    getNotification(): Observable<Notification> {
        return this.errorNotification.asObservable();
    }
    
}