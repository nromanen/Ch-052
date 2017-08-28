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
const UserRegisterModel_1 = require("../models/UserRegisterModel");
const forms_1 = require("@angular/forms");
const registration_service_1 = require("../services/registration.service");
let RegistrationComponent = class RegistrationComponent {
    constructor(formBuild, registrService) {
        this.formBuild = formBuild;
        this.registrService = registrService;
    }
    CreateRequest() {
        this.registrService.RegisterModel = this.registerModel;
        let result = this.registrService.PostUser();
        result.subscribe(function (response) { alert(response); window.location.replace("/start"); }, function (error) { alert(error); });
    }
    ngOnInit() {
        this.registrGroup = new forms_1.FormGroup({
            Name: new forms_1.FormControl(),
            Surname: new forms_1.FormControl(),
            Email: new forms_1.FormControl(),
            Password: new forms_1.FormControl(),
            ConfirmPassword: new forms_1.FormControl()
        });
    }
    //  public registerForm = this.formBuild.group({
    //     firstName:["",Validators.required],
    //     surname:["",Validators.required],
    //     eMail:["",Validators.required],
    //     password:["",Validators.required],
    //     passwordRepeat:["",Validators.required]
    //  });
    OnSubmit(registerModel, isValid) {
        this.registerModel = new UserRegisterModel_1.UserRegisterModel(registerModel.Name, registerModel.Surname, registerModel.Email, registerModel.Password, registerModel.ConfPassword);
        this.submitted = true;
        console.log(this.registerModel.Name + " " + this.registerModel.Surname);
        this.CreateRequest();
    }
};
RegistrationComponent = __decorate([
    core_1.Component({
        selector: 'advertisement-registration',
        templateUrl: `./registration.component.html`,
        styleUrls: ['./registration.component.css'],
    }),
    __metadata("design:paramtypes", [forms_1.FormBuilder, registration_service_1.RegistrationService])
], RegistrationComponent);
exports.RegistrationComponent = RegistrationComponent;
//# sourceMappingURL=registration.component.js.map