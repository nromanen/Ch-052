import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

import { Advertisement } from '../models/advertisement';
import { Category } from '../models/category';
import { Type } from '../models/type';

import { AdvertisementService } from '../services/advertisement.service';
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'loggedUserAds',
  templateUrl: './loggedUserAds.component.html',
  styleUrls: ['./loggedUserAds.component.css'],
  providers: [AdvertisementService, CategoryService, TypeService]
})

export class LoggedUserAdsComponent implements OnInit {
  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private typeService: TypeService,
    private categoryService: CategoryService
  ) { }

  title: string = 'Advertisements';

  advertisements: Advertisement[];
  private types: Type[];
  private categories: Type[];

  getLoggedUserAds(): void {
    this.advertisementService.getLoggedUserAds().then(advertisements =>
    { this.advertisements = advertisements; });
  }

  ngOnInit(): void {
    this.getTypes();
    this.getCategories();
    this.getLoggedUserAds();
  }

  getTypes(): void {
    this.typeService.getTypes().then(type => this.types = type);
  }

  getCategories(): void {
    this.categoryService.getCategories().then(category => this.categories = category);
  }
  deleteLoggedUserAds(feed: Advertisement): void {
    this.advertisementService
      .deleteLoggedUserAds(feed)
      .then(res => { this.getLoggedUserAds(); })
      .catch(error => console.log(error));
  }
  redirect(Id: number): void {
    this.router.navigate(['/info', Id]);
  }
}