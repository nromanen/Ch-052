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
const login_service_1 = require("../services/login.service");
require("rxjs/add/operator/toPromise");
require("rxjs/add/operator/toPromise");
let FeedbackService = class FeedbackService {
    constructor(http, loginService) {
        this.http = http;
        this.loginService = loginService;
    }
    getFeedbacks(id) {
        let feedbacksUrl = 'https://localhost:44384/api/feedback/getByAdvertisement' + id;
        return this.http.get(feedbacksUrl).toPromise().then(response => response.json()).catch(this.handleError);
    }
    postFeedback(param) {
        let authToken = localStorage.getItem("access_token");
        let headers = new http_1.Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new http_1.RequestOptions({ headers: headers });
        return this.http
            .post('https://localhost:44384/api/feedback/add', param, options)
            .toPromise()
            .then()
            .catch();
    }
    updateFeedback(param) {
        let authToken = localStorage.getItem("access_token");
        let headers = new http_1.Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new http_1.RequestOptions({ headers: headers });
        return this.http
            .put('https://localhost:44384/api/feedback/edit', param, options)
            .toPromise()
            .then()
            .catch();
    }
    handleError(error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
};
FeedbackService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, login_service_1.LoginService])
], FeedbackService);
exports.FeedbackService = FeedbackService;
//# sourceMappingURL=feedback.service.js.map