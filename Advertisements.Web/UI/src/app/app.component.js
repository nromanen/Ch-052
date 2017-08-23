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
const login_service_1 = require("./services/login.service");
const comcom_service_1 = require("./services/comcom.service");
const router_1 = require("@angular/router");
let AppComponent = class AppComponent {
    constructor(router, loginService, comcomService) {
        this.router = router;
        this.loginService = loginService;
        this.comcomService = comcomService;
        this.title = 'Advertisements';
        this.loginbuttontext = 'Log In';
        this.subscription = this.comcomService.getToken().subscribe(token => {
            this.token = token;
            if (token !== null)
                this.loginbuttontext = 'Welcome, ' + token.userName;
            else
                this.loginbuttontext = 'Log In';
        });
    }
    ngOnInit() {
    }
    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
};
AppComponent = __decorate([
    core_1.Component({
        moduleId: module.id.toString(),
        selector: 'app-root',
        templateUrl: './app.component.html',
        styleUrls: ['./app.component.css'],
        providers: [comcom_service_1.ComcomService],
    }),
    __metadata("design:paramtypes", [router_1.Router, login_service_1.LoginService, comcom_service_1.ComcomService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map