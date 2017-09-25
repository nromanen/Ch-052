import { Component, OnInit, Directive, Input } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response, Http, RequestOptions, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { DomSanitizer, ɵBROWSER_SANITIZATION_PROVIDERS } from '@angular/platform-browser';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { UsersService } from "../services/users.service";
import { AspNetUserModel } from "../models/AspNetUserModel";
import { Advertisement } from "../models/advertisement";
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';
import { AdvertisementService } from "../services/advertisement.service";

import { Type } from '../models/type';
import { Category } from '../models/category';

@Component({
    templateUrl: './userInfo.component.html',
    styleUrls: ['./userInfo.component.css'],
    providers: [UsersService, TypeService, CategoryService, AdvertisementService]
})
export class UserInfoComponent implements OnInit {
    private Avatar: string;
    private types: Type[];
    private categories: Type[];
    private AspNetUser: AspNetUserModel;
    private Advertisements: Advertisement[];

    public constructor(private ActivRoute: ActivatedRoute,
        private UserService: UsersService,
        private TService: TypeService,
        private CatService: CategoryService,
        private advService: AdvertisementService,
        private Sanitizer: DomSanitizer,
        private router: Router)
    { }

    ngOnInit() {
        let userId;
        this.ActivRoute.queryParams.subscribe((param: Params) => {
            userId = param["id"];
            this.getCategories();
            this.getTypes();

            this.UserService.GetAspNetUser(userId).then((result) => {
                this.AspNetUser = result;
                this.getUserAvatar();
                this.getUserAdvertisements();
            });
        }

        );
    }

    getUserAdvertisements(): void {
        this.advService.getAdsByUser(this.AspNetUser.Id).then(advs => this.Advertisements = advs);
    }

    getTypes(): void {
        this.TService.getTypes().then(type => this.types = type);
    }

    getCategories(): void {
        this.CatService.getCategories().then(category => this.categories = category);
    }
    getUserAvatar(): void {
        this.Avatar = "data:image/jpg;base64, ";
        this.UserService.GetUserAvatar(this.AspNetUser.Id).then(base64strAvatar => this.Avatar += base64strAvatar);
    }

    getPhotoUrl() {
        return this.Sanitizer.bypassSecurityTrustUrl(this.Avatar);
    }
    redirect(Id: number): void {
        this.router.navigate(['/info', Id]);
    }
}