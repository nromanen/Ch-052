import { Component, OnInit, Input, NgZone } from '@angular/core';
import { NgFor } from '@angular/common';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

import 'rxjs/add/operator/switchMap';


@Component({
    moduleId: module.id.toString(),
    selector: 'category-root',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css'],
    providers: [CategoryService]
})
export class CategoryComponent implements OnInit {
    constructor(private router: Router, private categoryService: CategoryService, private zone: NgZone) { }

    title: string = "Categories";

    categories: Category[];
    selectedCategory: Category;

    @Input() Category: Category = new Category();

    getCategories(): void {
        this.categoryService.getCategories()
            .then(categories =>
            { this.categories = categories; });
    }

    getCategory(id: number): void {
        this.categoryService.getCategory(id)
            .then();
    }

    deleteCategory(category: Category): void {
        this.categoryService.deleteCategory(category).
            then();
    }

    ngOnInit(): void {
        this.getCategories();
    }


    updateClick(category: Category): void {
        this.Category = category;
    }

    deleteClick(category): void {
        this.Category = category;
        this.categoryService.deleteCategory(this.Category).then(category => { this.getCategories(); }).catch(error => console.log(error));
        this.Category = new Category();
    }

    saveClick(): void {

        if (this.Category.Id == 0)
            this.categoryService.createCategory(this.Category).then(category => { this.getCategories() }).catch(error => console.log(error));
        else
            this.categoryService.updateCategory(this.Category).then(category => { this.getCategories() }).catch(error => console.log(error));

        this.Category = new Category();
    }

}