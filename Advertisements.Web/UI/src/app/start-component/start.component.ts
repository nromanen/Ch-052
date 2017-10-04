import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Router } from '@angular/router';

import { AdvertisementService } from '../services/advertisement.service';
import { LoginService } from '../services/login.service';
import { Type } from '../models/type';
import { Category } from '../models/category';
import { Observable } from "rxjs/Observable";

import { Token } from '../models/token';
import { Advertisement } from '../models/advertisement';
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';
import { UsersService } from "../services/users.service";
import { AdvertisementsUserModel } from "../models/AdvertisementsUserModel";
import * as _ from 'underscore';
import { PagerService } from "../services/pager.service";

@Component({
  moduleId: module.id.toString(),
  selector: 'start-root',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  providers: [AdvertisementService, CategoryService, TypeService,UsersService]
})
export class StartComponent implements OnInit{
  token: Token;

  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private loginService: LoginService,
    private typeService: TypeService,
    private categoryService: CategoryService,
    private usersService: UsersService,
    private pagerService: PagerService
  ) { 
    this.CurrentPageSize = 2;    
  }
  title: string = 'Advertisements';

  private isDataLoaded: boolean = false;
  advertisements: Advertisement[];
  selectedAdvertisement: Advertisement;
  private types: Type[];
  private categories: Category[];
  private Users: AdvertisementsUserModel[];
  private AllAdvsCount: number;
  private PageSizes: number[];
  private CurrentPageSize: number;
  pager: any = {};

  public setPage(page: number) {
    if (page < 1 || page > this.pager.totalPages) {
        return;
    }

    this.pager = this.pagerService.getPager(this.AllAdvsCount, page, this.CurrentPageSize);
    
    this.getAdvertisements();
}

  ngOnInit(): void {
    this.PageSizes = [2, 3, 5, 10];
    this.getAdvertisementsCount();
    //this.setPage(1);
    this.getUsers();
    this.getTypes();
    this.getCategories();    
  }
 
  getAdvertisementsCount():void
  {
    this.advertisementService.getAdsCount().then(result =>{
      this.AllAdvsCount = result;
      this.setPage(1);});
  }

  getAdvertisements(): void {
    this.advertisementService.getAds(this.pager.pageSize,this.pager.currentPage).then(result => { this.advertisements = result; });
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

 private SetSize(size: number): void
 {
   if(size == this.CurrentPageSize)
    return;
  this.CurrentPageSize = size;
  this.setPage(this.pager.currentPage);
 }

  

  redirect(Id: number): void {
    this.router.navigate(['/info', Id]);
  }

  redirectToUserInfo(ApplicationUserId: string)
  {
    this.router.navigate(['/userinfo'], {queryParams: { id: ApplicationUserId }});  
  }


}
