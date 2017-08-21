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
const advertisement_service_1 = require("../services/advertisement.service");
const login_service_1 = require("../services/login.service");
const router_1 = require("@angular/router");
let StartComponent = class StartComponent {
    constructor(router, advertisementService, loginService) {
        //this.token = this.loginService.getToken();
        //console.log(this.loginService.getToken());
        this.router = router;
        this.advertisementService = advertisementService;
        this.loginService = loginService;
        this.title = 'Advertisements';
    }
    getAdvertisements() {
        this.advertisementService.getAdvertisements().then(result => { this.advertisements = result; });
    }
    ngOnInit() {
        this.getAdvertisements();
    }
};
StartComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'start-root',
        templateUrl: './start.component.html',
        styleUrls: ['./start.component.css'],
        providers: [advertisement_service_1.AdvertisementService]
    }),
    __metadata("design:paramtypes", [router_1.Router, advertisement_service_1.AdvertisementService, login_service_1.LoginService])
], StartComponent);
exports.StartComponent = StartComponent;
//# sourceMappingURL=start.component.js.map