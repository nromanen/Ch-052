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
const advertisementCurrent_service_1 = require("../services/advertisementCurrent.service");
let UsersAdvComponent = class UsersAdvComponent {
    constructor(router, advertisementCurrentService) {
        this.router = router;
        this.advertisementCurrentService = advertisementCurrentService;
        this.title = 'Advertisements';
    }
    getCurrentAdvertisements() {
        this.advertisementCurrentService.getCurrentAdvertisements().then(advertisements => { this.advertisements = advertisements; console.log(this.advertisements); });
    }
    ngOnInit() {
        this.getCurrentAdvertisements();
    }
    remove(feed) {
        console.log(feed);
        this.advertisementCurrentService
            .deleteCurrentAdv(feed)
            .then(feedback => { this.getCurrentAdvertisements(); })
            .catch(error => console.log(error));
    }
};
UsersAdvComponent = __decorate([
    core_1.Component({
        moduleId: module.id.toString(),
        selector: 'usersAdv',
        templateUrl: './usersAdv.component.html',
        styleUrls: ['./usersAdv.component.css'],
        providers: [advertisementCurrent_service_1.AdvertisementCurrentService]
    }),
    __metadata("design:paramtypes", [router_1.Router, advertisementCurrent_service_1.AdvertisementCurrentService])
], UsersAdvComponent);
exports.UsersAdvComponent = UsersAdvComponent;
//# sourceMappingURL=usersAdv.component.js.map