import { Component, OnInit } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { LoginService } from '../services/login.service';
import { Token } from '../models/token';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { SearchService } from "../services/search.service";
import { TypeService } from '../services/type.service';
import { CategoryService } from '../services/category.service';
import { Type } from '../models/type';
import { Category } from '../models/category';


@Component({
    templateUrl: './search.component.html',
    providers: [SearchService]
})

export class SearchComponent implements OnInit {
    private KeyWord: string;
    public advertisements: Advertisement[];
    public constructor(
        private MyRoute: ActivatedRoute,
        private MyService: SearchService,
        private typeService: TypeService,
        private categoryService: CategoryService
    )
    { }
    private types: Type[];
    private categories: Category[];

    ngOnInit() {
        this.MyRoute.queryParams.forEach( (params) => {
            this.KeyWord = params["keyword"];
            
            if (this.KeyWord == null || this.KeyWord == "")
                return;
            
            this.getTypes();
            this.getCategories();
            this.MyService.Search(this.KeyWord).then((result) => {this.advertisements = result;  });
        });
        
        
    }
    getTypes(): void {
        this.typeService.getTypes().then(type => this.types = type);
    }

    getCategories(): void {
        this.categoryService.getCategories().then(category => this.categories = category);
    }
}