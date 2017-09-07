import { Component, OnInit, ElementRef, Input, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { Subscription } from "rxjs/Subscription";

import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';
import { AdvertisementService } from '../services/advertisement.service';

import { Advertisement } from '../models/advertisement';
import { Resource } from "../models/resource";
import { Category } from '../models/category';
import { Type } from '../models/type';

@Component({
  selector: 'createAdv',
  templateUrl: './createAdv.component.html',
  styleUrls: ['./createAdv.component.css'],
  providers: [AdvertisementService, CategoryService, TypeService]
})

export class CreateAdvComponent implements OnInit {
  constructor(private router: Router,
    private advertisementService: AdvertisementService,
    private typeService: TypeService,
    private categoryService: CategoryService,
    private route: ActivatedRoute,
    private http: Http) { }

  resource: Resource = new Resource();
  advertisement: Advertisement = new Advertisement();
  categories: Category[];
  types: Type[];
  files: File[];
  formData: FormData;

  ngOnInit() {
    this.getCategories();
    this.getTypes();
  }

  onSubmit(advertisement): void {
    this.advertisementService.createAdv(advertisement, this.resource).subscribe();
  }
  getCategories(): void {
    this.categoryService.getCategories().then(category => this.categories = category);
  }
  getTypes(): void {
    this.typeService.getTypes().then(type => this.types = type);
  }

  multiple: boolean = false;
  @ViewChild('fileInput') inputEl: ElementRef;

  upload() {
    let inputEl: HTMLInputElement = this.inputEl.nativeElement;
    let fileCount: number = inputEl.files.length;
    let formData = new FormData();
    if (fileCount > 0) {
      for (let i = 0; i < fileCount; i++) {
        formData.append('file[]', inputEl.files.item(i));
      }
      this.http
        .post('/api/Advertisement/upload', formData).subscribe(r => this.resource.Url = r.text());
      console.log(this.resource)
    }
  }
}