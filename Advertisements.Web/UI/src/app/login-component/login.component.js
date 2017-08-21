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
const common_1 = require("@angular/common");
const router_1 = require("@angular/router");
const login_service_1 = require("../services/login.service");
const register_view_model_1 = require("../models/register.view.model");
require("rxjs/add/operator/switchMap");
let LoginComponent = class LoginComponent {
    constructor(loginService, location, router) {
        this.loginService = loginService;
        this.location = location;
        this.router = router;
        this.registerViewModel = new register_view_model_1.RegisterViewModel;
    }
    goClick() {
        this.registerViewModel.Username = this.registerViewModel.Email;
        this.registerViewModel.grant_type = 'password';
        this.loginService.login(this.registerViewModel).subscribe(response => {
            this.token = response;
            localStorage.setItem('access_token', this.token.access_token);
            localStorage.setItem('expires_in', this.token.expires_in.toString());
            localStorage.setItem('user_name', this.token.userName);
            this.router.navigate(['/start']);
        }, err => console.log('Something went wrong!'));
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", register_view_model_1.RegisterViewModel)
], LoginComponent.prototype, "registerViewModel", void 0);
LoginComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'advertisement-login',
        templateUrl: `./login.component.html`,
        styleUrls: [`./login.component.css`]
    }),
    __metadata("design:paramtypes", [login_service_1.LoginService,
        common_1.Location,
        router_1.Router])
], LoginComponent);
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map