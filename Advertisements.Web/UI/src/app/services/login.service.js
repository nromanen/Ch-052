"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
require("rxjs/add/operator/map");
require("rxjs/add/operator/toPromise");
let LoginService = class LoginService {
    constructor(http) {
        this.http = http;
        this.advertisementsLoginUrl = '/Token';
    }
    handleError(error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
    logout() {
        localStorage.removeItem("access_token");
        localStorage.removeItem("expires_in");
        localStorage.removeItem("user_name");
    }
    login(params) {
        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('Username', params.Username);
        urlSearchParams.append('Password', params.Password);
        urlSearchParams.append('grant_type', params.grant_type);
        let body = urlSearchParams.toString();
        return this.http.post(this.advertisementsLoginUrl, body).map(res => { return res.json(); });
        //    return this.http.post(this.advertisementsLoginUrl, body).toPromise().then(response => {this.token = response.json() as Token; 
        //    localStorage.setItem('access_token', this.token.access_token);    
        //    localStorage.setItem('expires_in', this.token.expires_in.toString());  
        //    localStorage.setItem('user_name', this.token.userName);  
        //    this.status = response.status;} ).catch(this.handleError);
    }
    isLoggedin() {
        // if (tokenNotExpired())
        //     return true;
        // else
        //     return false;
    }
    getToken() {
        return this.token;
    }
    getStatus() {
        return this.status;
    }
};
LoginService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], LoginService);
exports.LoginService = LoginService;
//# sourceMappingURL=login.service.js.map