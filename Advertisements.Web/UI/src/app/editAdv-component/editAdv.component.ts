import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from "rxjs/Subscription";

import { AdvertisementService } from '../services/advertisement.service';
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';

import { Advertisement } from '../models/advertisement';
import { Category } from '../models/category';
import { Type } from '../models/type';

@Component({
  selector: 'editAdv',
  templateUrl: './editAdv.component.html',
  styleUrls: ['./editAdv.component.css'],
  providers: [AdvertisementService, CategoryService, TypeService]
})

export class EditAdvComponent implements OnInit, OnDestroy {
  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private route: ActivatedRoute,
    private typeService: TypeService,
    private categoryService: CategoryService) { }

  private id: number;
  private route$: Subscription;
  title: string = 'Edit';
  categories: Category[];
  types: Type[];

  advertisement: Advertisement = new Advertisement();

  ngOnInit() {
    this.route$ = this.route.params.subscribe(
      (params: Params) => {
        this.id = +params["id"];
      }
    );
    this.getCategories();
    this.getTypes();
    this.getAdvertisement(this.id)

  }

  ngOnDestroy() {
    if (this.route$) this.route$.unsubscribe();
  }

  getAdvertisement(id): void {
    this.advertisementService.getAdv(id).then(advertisement => { this.advertisement = advertisement; });
  }

  onSubmit(advertisement): void {
    this.advertisementService.editLoggedUserAdv(advertisement).subscribe(r => this.router.navigate(['/myAdv']));
  }
  getCategories(): void {
    this.categoryService.getCategories().then(category => this.categories = category);
  }
  getTypes(): void {
    this.typeService.getTypes().then(type => this.types = type);
  }
}