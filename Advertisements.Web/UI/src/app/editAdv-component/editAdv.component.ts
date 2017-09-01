import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { EditAdvService } from '../services/editAdv.service';
import { Subscription } from "rxjs/Subscription";
import { Category } from '../models/category';
import { Type } from '../models/type';

@Component({
  selector: 'editAdv',
  templateUrl: './editAdv.component.html',
  styleUrls: ['./editAdv.component.css'],
  providers: [EditAdvService]
})

export class EditAdvComponent implements OnInit, OnDestroy {
  constructor(private router: Router, private editAdvService: EditAdvService, private route: ActivatedRoute) { }

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
    this.editAdvService.getAdvertisement(id).then(advertisement => { this.advertisement = advertisement; });
  }

  onSubmit(advertisement): void {
    this.editAdvService.editAdv(advertisement).subscribe(r => this.router.navigate(['/myAdv']));
  }
  getCategories(): void {
    this.editAdvService.getCategory().then(category => this.categories = category.json() as Category[]);
  }
  getTypes(): void {
    this.editAdvService.getType().then(type => this.types = type.json() as Type[]);
  }
}