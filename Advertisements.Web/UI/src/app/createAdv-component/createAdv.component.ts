import { Component, OnInit, ElementRef, Input, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http } from '@angular/http';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { CreateAdvService } from '../services/createAdv.service';
import { Subscription } from "rxjs/Subscription";
import { Category } from '../models/category';
import { Type } from '../models/type';
import { Resource } from "../models/resource";

@Component({
  selector: 'createAdv',
  templateUrl: './createAdv.component.html',
  styleUrls: ['./createAdv.component.css'],
  providers: [CreateAdvService]
})

export class CreateAdvComponent implements OnInit {
  constructor(private router: Router,
    private createAdvService: CreateAdvService,
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
    this.createAdvService.createAdv(advertisement, this.resource).subscribe(r => this.router.navigate(['/start']));
  }
  getCategories(): void {
    this.createAdvService.getCategory().then(category => this.categories = category.json() as Category[]);
  }
  getTypes(): void {
    this.createAdvService.getType().then(type => this.types = type.json() as Type[]);
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