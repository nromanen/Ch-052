import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../models/UserRegisterModel'
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response, Http, RequestOptions, Headers } from '@angular/http';
import { RegistrationService } from '../services/registration.service'
import { Observable } from 'rxjs/Observable';

@Component({
    templateUrl: './tryrestorepassword.component.html',
    styleUrls: ['./tryrestorepassword.component.css']
})
export class TryRestorePasswordCompoent implements OnInit {
    private MyHttpClient: Http;
    private CheckEmailUrl: string;
    private emailForm: FormGroup;
    public constructor(http: Http) {
        this.MyHttpClient = http;
        this.CheckEmailUrl = "/api/Account/RestorePasswordRequest";
    }

    public ngOnInit(): void {
        this.emailForm = new FormGroup({
            email: new FormControl()
        });
    }

    public CheckEmail(email: string): void {
        let result;
        this.SendRequestForCheck(email).subscribe((res) => {
            result = res;
            this.TakeResult(result);
        });
    }
    public SendRequestForCheck(email: string): Observable<Response> {
        let header = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: header });

        return this.MyHttpClient.post(this.CheckEmailUrl, email, options).map(res => res.json());
    }
    private TakeResult(response: Response): void {
        if (response.toString() == "Check your email to restore your password!") {
            alert(response.toString());
            window.location.replace("/start");
        }
        else
            alert(response.toString());
    }
}