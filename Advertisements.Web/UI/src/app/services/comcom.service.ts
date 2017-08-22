import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';

import {Token} from '../models/token'

@Injectable()
export class ComcomService {

    private comcomSubject = new Subject<Token>();

    sendToken(token: Token) {
        this.comcomSubject.next(token);
    }

    clearToken() {
        this.comcomSubject.next();
    }

    getToken(): Observable<Token> {
        return this.comcomSubject.asObservable();
    }
}