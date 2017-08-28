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
const editAdv_service_1 = require("../services/editAdv.service");
let EditAdvComponent = class EditAdvComponent {
    constructor(router, editAdvService, route) {
        this.router = router;
        this.editAdvService = editAdvService;
        this.route = route;
        this.title = 'Edit';
        this.advertisement = new advertisement_1.Advertisement();
    }
    ngOnInit() {
        this.route$ = this.route.params.subscribe((params) => {
            this.id = +params["id"];
        });
        this.getCategories();
        this.getTypes();
        this.getAdvertisement(this.id);
    }
    ngOnDestroy() {
        if (this.route$)
            this.route$.unsubscribe();
    }
    getAdvertisement(id) {
        this.editAdvService.getAdvertisement(id).then(advertisement => { this.advertisement = advertisement; console.log(this.advertisement); });
    }
    onSubmit(advertisement) {
        this.editAdvService.editAdv(advertisement);
    }
    getCategories() {
        this.editAdvService.getCategory().then(category => this.categories = category.json());
    }
    getTypes() {
        this.editAdvService.getType().then(type => this.types = type.json());
    }
};
EditAdvComponent = __decorate([
    core_1.Component({
        selector: 'editAdv',
        templateUrl: './editAdv.component.html',
        styleUrls: ['./editAdv.component.css'],
        providers: [editAdv_service_1.EditAdvService]
    }),
    __metadata("design:paramtypes", [router_1.Router, editAdv_service_1.EditAdvService, router_1.ActivatedRoute])
], EditAdvComponent);
exports.EditAdvComponent = EditAdvComponent;
//# sourceMappingURL=editAdv.component.js.map