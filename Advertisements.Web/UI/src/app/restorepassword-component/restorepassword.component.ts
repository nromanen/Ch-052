import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../models/UserRegisterModel'
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response } from '@angular/http';
import { RegistrationService } from '../services/registration.service'
import {Router, ActivatedRoute, Params} from '@angular/router';
import { RestorePasswordViewModel } from "../models/RestorePasswordViewModel";
import {RestorePasswordService} from '../services/restorepassword.service'  
@Component({
    templateUrl: './restorepassword.component.html',
    styleUrls: ['./restorepassword.component.css']
})

export class RestorePasswordComponent implements OnInit
{
    private RestPassService: RestorePasswordService;
    private AccessRoute: ActivatedRoute; 
    private EmailToken: string;
    private Email: string;
    private IsReady: boolean;
    private IsRightUrl: boolean;
    public restorePasswordForm: FormGroup;
    public constructor(route: ActivatedRoute, service: RestorePasswordService)
    {
        this.AccessRoute = route;
        this.RestPassService = service;
        this.IsReady = false;
    }

    ngOnInit(): void
    {
        this.AccessRoute.queryParams.subscribe((params: Params)=>
        {
            this.EmailToken = params['token'];
            this.Email = params['email'];

            this.restorePasswordForm = new FormGroup({
                NewPassword: new FormControl(),
                ConfNewPass: new FormControl()
            });

            
        });
        
        if(this.EmailToken == null || this.Email == null){
            this.IsReady = true;
            return;
        }

        this.RestPassService.CheckEmailAndToken(this.Email,this.EmailToken).subscribe((result)=> this.IsRightUrl = this.GetCheckDataResponse(result.toString()));

    }
    GetCheckDataResponse(responseText: string): boolean
    {
        this.IsReady = true;
        if(responseText != "Ok")
            return false;
        else
            return true;
    }

    RestorePass(model: RestorePasswordViewModel)
    {
        this.RestPassService.ResetPassword(model.NewPassword).subscribe((result)=> 
        {
            alert(result);
            window.location.replace("/start");
        });
    }
}