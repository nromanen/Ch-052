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
const feedback_component_1 = require("./feedback-component/feedback.component");
const usersAdv_component_1 = require("./usersAdv-component/usersAdv.component");
const editAdv_component_1 = require("./editAdv-component/editAdv.component");
const createAdv_component_1 = require("./createAdv-component/createAdv.component");
const advInfo_component_1 = require("./advInfo-component/advInfo.component");
const advertisement_service_1 = require("./services/advertisement.service");
const login_service_1 = require("./services/login.service");
const feedback_service_1 = require("./services/feedback.service");
const comcom_service_1 = require("./services/comcom.service");
const advertisementCurrent_service_1 = require("./services/advertisementCurrent.service");
const editAdv_service_1 = require("./services/editAdv.service");
const createAdv_service_1 = require("./services/createAdv.service");
const advInfo_service_1 = require("./services/advInfo.service");
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
            editAdv_component_1.EditAdvComponent,
            createAdv_component_1.CreateAdvComponent,
            advInfo_component_1.AdvInfoComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            http_1.HttpModule,
            app_routing_module_1.AppRoutingModule,
            forms_1.FormsModule
        ],
        providers: [advertisement_service_1.AdvertisementService, login_service_1.LoginService, feedback_service_1.FeedbackService, comcom_service_1.ComcomService, advertisementCurrent_service_1.AdvertisementCurrentService, editAdv_service_1.EditAdvService, createAdv_service_1.CreateAdvService, advInfo_service_1.AdvInfoService],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map