"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const platform_browser_1 = require("@angular/platform-browser");
const http_1 = require("@angular/http");
const forms_1 = require("@angular/forms");
const app_routing_module_1 = require("./app-routing.module");
const core_1 = require("@angular/core");
const app_component_1 = require("./app.component");
const login_component_1 = require("./login-component/login.component");
const start_component_1 = require("./start-component/start.component");
const usersAdv_component_1 = require("./usersAdv-component/usersAdv.component");
const feedback_component_1 = require("./feedback-component/feedback.component");
const advertisement_service_1 = require("./services/advertisement.service");
const login_service_1 = require("./services/login.service");
const feedback_service_1 = require("./services/feedback.service");
const comcom_service_1 = require("./services/comcom.service");
const registration_component_1 = require("./registration-component/registration.component");
const equalvalidator_directive_1 = require("./directives/equalvalidator.directive");
const registration_service_1 = require("./services/registration.service");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        declarations: [
            app_component_1.AppComponent,
            login_component_1.LoginComponent,
            start_component_1.StartComponent,
            feedback_component_1.FeedbackComponent,
            usersAdv_component_1.UsersAdvComponent,
            registration_component_1.RegistrationComponent,
            equalvalidator_directive_1.EqualValidator
        ],
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpModule,
            app_routing_module_1.AppRoutingModule,
            forms_1.FormsModule,
            forms_1.ReactiveFormsModule
        ],
        providers: [advertisement_service_1.AdvertisementService, login_service_1.LoginService, feedback_service_1.FeedbackService, comcom_service_1.ComcomService, registration_service_1.RegistrationService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map