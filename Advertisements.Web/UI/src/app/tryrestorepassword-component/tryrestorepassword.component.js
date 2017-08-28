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
const forms_1 = require("@angular/forms");
const http_1 = require("@angular/http");
let TryRestorePasswordCompoent = class TryRestorePasswordCompoent {
    constructor(http) {
        this.MyHttpClient = http;
        this.CheckEmailUrl = "/api/Account/RestorePasswordRequest";
    }
    ngOnInit() {
        this.emailForm = new forms_1.FormGroup({
            email: new forms_1.FormControl()
        });
    }
    CheckEmail(email) {
        let result;
        this.SendRequestForCheck(email).subscribe((res) => {
            result = res;
            this.TakeResult(result);
        });
    }
    SendRequestForCheck(email) {
        let header = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: header });
        return this.MyHttpClient.post(this.CheckEmailUrl, email, options).map(res => res.json());
    }
    TakeResult(response) {
        if (response.toString() == "Check your email to restore your password!") {
            alert(response.toString());
            window.location.replace("/start");
        }
        else
            alert(response.toString());
    }
};
TryRestorePasswordCompoent = __decorate([
    core_1.Component({
        templateUrl: './tryrestorepassword.component.html',
        styleUrls: ['./tryrestorepassword.component.css']
    }),
    __metadata("design:paramtypes", [http_1.Http])
], TryRestorePasswordCompoent);
exports.TryRestorePasswordCompoent = TryRestorePasswordCompoent;
//# sourceMappingURL=tryrestorepassword.component.js.map