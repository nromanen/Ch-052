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
const router_1 = require("@angular/router");
const advertisement_1 = require("../models/advertisement");
const advInfo_service_1 = require("../services/advInfo.service");
let AdvInfoComponent = class AdvInfoComponent {
    constructor(router, infoAdvService, route) {
        this.router = router;
        this.infoAdvService = infoAdvService;
        this.route = route;
        this.title = 'Info of advertisement: id =';
        this.advertisement = new advertisement_1.Advertisement();
    }
    ngOnInit() {
        this.route$ = this.route.params.subscribe((params) => {
            this.id = +params["id"];
        });
        this.getAdvertisement(this.id);
        this.title += this.id;
    }
    ngOnDestroy() {
        if (this.route$)
            this.route$.unsubscribe();
    }
    getAdvertisement(id) {
        this.infoAdvService.getAdvertisement(id).then(advertisement => { this.advertisement = advertisement; console.log(this.advertisement); });
    }
};
AdvInfoComponent = __decorate([
    core_1.Component({
        selector: 'advInfo',
        templateUrl: './advInfo.component.html',
        styleUrls: ['./advInfo.component.css'],
        providers: [advInfo_service_1.AdvInfoService]
    }),
    __metadata("design:paramtypes", [router_1.Router, advInfo_service_1.AdvInfoService, router_1.ActivatedRoute])
], AdvInfoComponent);
exports.AdvInfoComponent = AdvInfoComponent;
//# sourceMappingURL=advInfo.component.js.map