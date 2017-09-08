import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from "rxjs/Subscription";

import { Advertisement } from '../models/advertisement';
import { Type } from '../models/type';
import { Category } from '../models/category';

import { AdvertisementService } from '../services/advertisement.service';
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'advInfo',
  templateUrl: './advInfo.component.html',
  styleUrls: ['./advInfo.component.css'],
  providers: [AdvertisementService, TypeService]
})

export class AdvInfoComponent implements OnInit, OnDestroy {
  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private route: ActivatedRoute,
    private typeService: TypeService,
    private categoryService: CategoryService
  ) { }

  private id: number;
  private route$: Subscription;
  advertisement: Advertisement;
  private types: Type[];
  private categories: Category[];

  ngOnInit() {
    this.route$ = this.route.params.subscribe(
      (params: Params) => {
        this.id = +params["id"];
      }
    );
    this.getTypes();
    this.getCategories();
    this.getAdvertisement(this.id);
  }

  getTypes(): void {
    this.typeService.getTypes().then(type => this.types = type);
  }

  getCategories(): void {
    this.categoryService.getCategories().then(category => this.categories = category);
  }

  ngOnDestroy() {
    if (this.route$) this.route$.unsubscribe();
  }
  getAdvertisement(id): void {
    this.advertisementService.getAdv(id).then(advertisement => { this.advertisement = advertisement;});
  }

}
