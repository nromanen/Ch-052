import { Component, OnInit, Input, NgZone } from "@angular/core";
import { NgFor } from "@angular/common";
import { Type } from "../models/type";
import { TypeService } from "../services/type.service";
import { Router, ActivatedRoute, Params } from "@angular/router";

import 'rxjs/add/operator/switchMap';

@Component({
    moduleId: module.id.toString(),
    selector: "type-root",
    templateUrl: "./type.component.html",
    styleUrls: ['./type.component.css'],
    providers: [TypeService]
})
export class TypeComponent implements OnInit {
    constructor(private router: Router, private typeService: TypeService, private zone: NgZone) { }

    title: string = "Types";

    types: Type[];
    selectedType: Type;

    @Input() Type: Type = new Type();

     getTypes(): void {
        this.typeService.getTypes()
            .then(types =>
            { this.types = types; console.log("Component", this.types) });
    }

    getType(id: number): void {
        this.typeService.getType(id)
            .then();
    }

    deleteType(type: Type): void {
        this.typeService.deleteType(type).
            then();
    }

    ngOnInit(): void {
        this.getTypes();
    }


    updateClick(type: Type): void {
        this.Type = type;
    }

    deleteClick(type): void {
        this.Type = type;
        this.typeService.deleteType(this.Type).then(type => { this.getTypes(); console.log(this.Type) }).catch(error => console.log(error));
        this.Type = new Type();
    }

    saveClick(): void {
        console.log(this.Type);

        if (this.Type.Id == 0)
            this.typeService.createType(this.Type).then(type => { this.getTypes() }).catch(error => console.log(error));
        else
            this.typeService.updateType(this.Type).then(type => { this.getTypes() }).catch(error => console.log(error));

        this.Type = new Type();
    }

}