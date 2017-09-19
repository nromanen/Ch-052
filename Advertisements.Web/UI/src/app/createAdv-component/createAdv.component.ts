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

    resource: Array<Resource> = new Array();
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

  multiple: boolean = true;
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
        .post('/api/Advertisement/upload', formData).subscribe(r => {
          var str = r.text();
          console.log("response string: " + str);
          var res = str.split(" ");
          for (let i = 0; i < res.length; i++) {
            if (res[i] != "" || res[i] != " " || res[i] != null) {
              console.log("substring" + res[i]);
              this.resource.push(new Resource());
              this.resource[this.resource.length-1].Url = res[i];
            }
          }
        });
    }
  }
}