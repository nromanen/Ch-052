import { Component, OnInit } from '@angular/core';
import { NgSwitch } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { LoginService } from '../services/login.service';
import { Token } from '../models/token';
import { Router, ActivatedRoute,Params } from '@angular/router';
import { SearchService } from "../services/search.service";

@Component({
    templateUrl: './search.component.html',
    providers: [SearchService]
})

export class SearchComponent implements OnInit
{
    private KeyWord:string;
    public Advertisements: Advertisement[];
    public constructor(
       private MyRoute: ActivatedRoute,
       private MyService: SearchService
    )
    {}

    ngOnInit()
    {
        this.MyRoute.queryParams.subscribe((params:Params) =>
            {
                this.KeyWord = params["keyword"];
                
                if(this.KeyWord == null || this.KeyWord == "")
                    return;
            }
        );
        this.MyService.keyword = this.KeyWord;
        this.MyService.Search().then((result)=>this.Advertisements = result);
    }
}