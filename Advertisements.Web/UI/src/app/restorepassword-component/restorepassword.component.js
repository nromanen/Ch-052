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
const router_1 = require("@angular/router");
const restorepassword_service_1 = require("../services/restorepassword.service");
let RestorePasswordComponent = class RestorePasswordComponent {
    constructor(route, service) {
        this.AccessRoute = route;
        this.RestPassService = service;
        this.IsReady = false;
    }
    ngOnInit() {
        this.AccessRoute.queryParams.subscribe((params) => {
            this.EmailToken = params['token'];
            this.Email = params['email'];
            this.restorePasswordForm = new forms_1.FormGroup({
                NewPassword: new forms_1.FormControl(),
                ConfNewPass: new forms_1.FormControl()
            });
        });
        if (this.EmailToken == null || this.Email == null) {
            this.IsReady = true;
            return;
        }
        this.RestPassService.CheckEmailAndToken(this.Email, this.EmailToken).subscribe((result) => this.IsRightUrl = this.GetCheckDataResponse(result.toString()));
    }
    GetCheckDataResponse(responseText) {
        this.IsReady = true;
        if (responseText != "Ok")
            return false;
        else
            return true;
    }
    RestorePass(model) {
        this.RestPassService.ResetPassword(model.NewPassword).subscribe((result) => {
            alert(result);
            window.location.replace("/start");
        });
    }
};
RestorePasswordComponent = __decorate([
    core_1.Component({
        templateUrl: './restorepassword.component.html',
        styleUrls: ['./restorepassword.component.css']
    }),
    __metadata("design:paramtypes", [router_1.ActivatedRoute, restorepassword_service_1.RestorePasswordService])
], RestorePasswordComponent);
exports.RestorePasswordComponent = RestorePasswordComponent;
//# sourceMappingURL=restorepassword.component.js.map