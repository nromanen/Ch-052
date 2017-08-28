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
let RestorePasswordService = class RestorePasswordService {
    constructor(http) {
        this.Email = null;
        this.Token = null;
        this.MyHttpService = http;
        this.CheckTokenAndEmailUrl = "/api/Account/CheckPassRestoreData";
        this.RestorePasswordUrl = "api/Account/RestorePassword";
    }
    CheckEmailAndToken(email, token) {
        this.Email = email;
        this.Token = token;
        let body = { Email: this.Email, Token: this.Token };
        let header = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: header });
        return this.MyHttpService.post(this.CheckTokenAndEmailUrl, body, options).map((result) => result.json());
    }
    ResetPassword(password) {
        if (this.Email == null || this.Token == null)
            return null;
        let body = { Email: this.Email, EmailToken: this.Token, NewPassword: password };
        let header = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: header });
        return this.MyHttpService.post(this.RestorePasswordUrl, body, options).map((result) => result.json());
    }
};
RestorePasswordService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], RestorePasswordService);
exports.RestorePasswordService = RestorePasswordService;
//# sourceMappingURL=restorepassword.service.js.map