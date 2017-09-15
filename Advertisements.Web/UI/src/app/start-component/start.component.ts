import { Component, OnInit } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Router } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { LoginService } from '../services/login.service';
import { Type } from '../models/type';
import { Category } from '../models/category';

import { Token } from '../models/token';
import { Advertisement } from '../models/advertisement';
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';
import { UsersService } from "../services/users.service";
import { AdvertisementsUserModel } from "../models/AdvertisementsUserModel";
@Component({
  moduleId: module.id.toString(),
  selector: 'start-root',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [AdvertisementService, CategoryService, TypeService,UsersService]
})
export class StartComponent implements OnInit {
  token: Token;

  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private loginService: LoginService,
    private typeService: TypeService,
    private categoryService: CategoryService,
    private usersService: UsersService
  ) { }
  title: string = 'Advertisements';

  private isDataLoaded: boolean = false;
  advertisements: Advertisement[];
  selectedAdvertisement: Advertisement;
  private types: Type[];
  private categories: Category[];
  private Users: AdvertisementsUserModel[];

  getAdvertisements(): void {
    this.advertisementService.getAds().then(result => { this.advertisements = result; });
  }

  getUsers():void
  {
    this.usersService.GetAdvertisementsUsers().then(users => this.Users = users);
  }

  getTypes(): void {
    this.typeService.getTypes().then(type => this.types = type);
  }

  getCategories(): void {
    this.categoryService.getCategories().then(category => this.categories = category);
  }

 public GetUserName(id:string):string
 {
    let user :AdvertisementsUserModel = this.Users.find(el => el.Id==id)
    if (user !=null)
      return user.UserName;
    else
      return "unknown";
 } 

  ngOnInit(): void {
    this.getUsers();
    this.getTypes();
    this.getCategories();
    this.getAdvertisements();
  }

  redirect(Id: number): void {
    this.router.navigate(['/info', Id]);
  }

  redirectToUserInfo(ApplicationUserId: string)
  {
    this.router.navigate(['/userinfo'], {queryParams: { id: ApplicationUserId }});  
  }
}
