import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../models/UserRegisterModel'
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response } from '@angular/http';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { RestorePasswordViewModel } from "../models/RestorePasswordViewModel";
import { RestorePasswordService } from '../services/restorepassword.service'
import { ConfirmEmailService } from '../services/confirmemail.service'
import { ComcomService } from '../services/comcom.service';
import { Notification } from "../models/notification";
@Component({
    templateUrl: './confirmemail.component.html'
})

export class ConfirmEmailComponent implements OnInit {
    private MyService: ConfirmEmailService;
    private IsReady: boolean;
    private Result: string;
    private MyRoute: ActivatedRoute;
    private Email: string;
    private Token: string;
    public constructor(route: ActivatedRoute, service: ConfirmEmailService, private comservice: ComcomService) {
        this.MyRoute = route;
        this.IsReady = false;
        this.MyService = service;;
    }

    ngOnInit() {
        this.MyRoute.queryParams.subscribe((params: Params) => {
            this.Token = params['token'];
            this.Email = params['email'];
        });
        this.MyService.SendRequest(this.Token, this.Email).subscribe((result) => this.TakeResponse(result.toString()));
    }
    private TakeResponse(response: string) {
        alert(response);
        window.location.replace("/start");
    }
}