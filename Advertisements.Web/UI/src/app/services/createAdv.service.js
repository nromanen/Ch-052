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
require("rxjs/add/operator/toPromise");
require("rxjs/add/operator/toPromise");
let CreateAdvService = class CreateAdvService {
    constructor(http) {
        this.http = http;
    }
    createAdv(param) {
        let authToken = localStorage.getItem("access_token");
        let headers = new http_1.Headers();
        headers.append('Authorization', `Bearer ${authToken}`);
        let options = new http_1.RequestOptions({ headers: headers });
        return this.http
            .get('api/AspNetUsers/get/current', options)
            .toPromise()
            .then(response => {
            console.log('response: ', response);
            param.ApplicationUserId = response.json();
            this.http
                .post('api/advertisement/add', param, options)
                .toPromise()
                .then()
                .catch();
        });
    }
    getCategory() {
        return this.http
            .get('api/Category/get')
            .toPromise()
            .then()
            .catch();
    }
    getType() {
        return this.http
            .get('api/AdvertisementType/get')
            .toPromise()
            .then()
            .catch();
    }
};
CreateAdvService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], CreateAdvService);
exports.CreateAdvService = CreateAdvService;
//# sourceMappingURL=createAdv.service.js.map