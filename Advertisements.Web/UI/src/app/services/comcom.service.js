"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const Subject_1 = require("rxjs/Subject");
let ComcomService = class ComcomService {
    constructor() {
        this.comcomSubject = new Subject_1.Subject();
    }
    sendToken(token) {
        this.comcomSubject.next(token);
    }
    clearToken() {
        this.comcomSubject.next();
    }
    getToken() {
        return this.comcomSubject.asObservable();
    }
};
ComcomService = __decorate([
    core_1.Injectable()
], ComcomService);
exports.ComcomService = ComcomService;
//# sourceMappingURL=comcom.service.js.map