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
const createAdv_service_1 = require("../services/createAdv.service");
let CreateAdvComponent = class CreateAdvComponent {
    constructor(router, createAdvService, route) {
        this.router = router;
        this.createAdvService = createAdvService;
        this.route = route;
        this.advertisement = new advertisement_1.Advertisement();
    }
    ngOnInit() {
        this.getCategories();
        this.getTypes();
    }
    onSubmit(advertisement) {
        this.createAdvService.createAdv(advertisement);
    }
    getCategories() {
        this.createAdvService.getCategory().then(category => this.categories = category.json());
    }
    getTypes() {
        this.createAdvService.getType().then(type => this.types = type.json());
    }
};
CreateAdvComponent = __decorate([
    core_1.Component({
        selector: 'createAdv',
        templateUrl: './createAdv.component.html',
        styleUrls: ['./createAdv.component.css'],
        providers: [createAdv_service_1.CreateAdvService]
    }),
    __metadata("design:paramtypes", [router_1.Router, createAdv_service_1.CreateAdvService, router_1.ActivatedRoute])
], CreateAdvComponent);
exports.CreateAdvComponent = CreateAdvComponent;
//# sourceMappingURL=createAdv.component.js.map