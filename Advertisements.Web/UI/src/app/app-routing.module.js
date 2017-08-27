"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const router_1 = require("@angular/router");
const login_component_1 = require("./login-component/login.component");
const start_component_1 = require("./start-component/start.component");
const feedback_component_1 = require("./feedback-component/feedback.component");
const usersAdv_component_1 = require("./usersAdv-component/usersAdv.component");
const registration_component_1 = require("./registration-component/registration.component");
const routes = [
    { path: '', redirectTo: '/start', pathMatch: 'full' },
    { path: 'start', component: start_component_1.StartComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'myAdv', component: usersAdv_component_1.UsersAdvComponent },
    { path: 'feedback', component: feedback_component_1.FeedbackComponent },
    { path: 'register', component: registration_component_1.RegistrationComponent }
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    core_1.NgModule({
        imports: [router_1.RouterModule.forRoot(routes)],
        exports: [router_1.RouterModule]
    })
], AppRoutingModule);
exports.AppRoutingModule = AppRoutingModule;
//# sourceMappingURL=app-routing.module.js.map