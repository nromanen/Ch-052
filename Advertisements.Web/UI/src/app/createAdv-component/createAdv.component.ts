import { Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { CreateAdvService } from '../services/createAdv.service';
import { Subscription } from "rxjs/Subscription";
import { Category } from '../models/category';
import { Type } from '../models/type';

@Component({
  selector: 'createAdv',
  templateUrl: './createAdv.component.html',
  styleUrls: ['./createAdv.component.css'],
  providers: [CreateAdvService]
})

export class CreateAdvComponent implements OnInit {
  constructor(private router: Router, private createAdvService: CreateAdvService, private route: ActivatedRoute) { }

  advertisement: Advertisement = new Advertisement();
  categories: Category[];
  types: Type[];

  ngOnInit() {
    this.getCategories();
    this.getTypes();
  }

  onSubmit(advertisement):void
  {
    this.createAdvService.createAdv(advertisement);
  }
  getCategories():void
  {
    this.createAdvService.getCategory().then(category => this.categories = category.json() as Category[]);
  }
  getTypes():void
  {
    this.createAdvService.getType().then(type => this.types = type.json() as Type[]);
  }
}