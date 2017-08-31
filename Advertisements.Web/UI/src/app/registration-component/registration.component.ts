import { Component, OnInit } from '@angular/core';
import { UserRegisterModel } from '../models/UserRegisterModel'
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response } from '@angular/http';
import { RegistrationService } from '../services/registration.service'
@Component({
  selector: 'advertisement-registration',
  templateUrl: `./registration.component.html`,
  styleUrls: ['./registration.component.css'],

})

export class RegistrationComponent implements OnInit //implements OnInit
{
  public serverResponse: Response;
  private registrService: RegistrationService;
  private registerModel: UserRegisterModel;
  private formBuild: FormBuilder;
  private registrGroup: FormGroup;
  public submitted: boolean;

  public constructor(formBuild: FormBuilder, registrService: RegistrationService) {
    this.formBuild = formBuild;
    this.registrService = registrService;
  }

  private CreateRequest(): void {
    this.registrService.RegisterModel = this.registerModel;
    let result = this.registrService.PostUser();
    result.subscribe(
      function(response) { alert(response); window.location.replace("/start");},
      function(error) { }
  );
  }

  ngOnInit(): void {
    this.registrGroup = new FormGroup({
      Name: new FormControl(),
      Surname: new FormControl(),
      Email: new FormControl(),
      Password: new FormControl(),
      ConfirmPassword: new FormControl()
    });
  }


  //  public registerForm = this.formBuild.group({
  //     firstName:["",Validators.required],
  //     surname:["",Validators.required],
  //     eMail:["",Validators.required],
  //     password:["",Validators.required],
  //     passwordRepeat:["",Validators.required]
  //  });

  public OnSubmit(registerModel: UserRegisterModel, isValid: boolean): void {
    this.registerModel = new UserRegisterModel(registerModel.Name, registerModel.Surname,
      registerModel.Email, registerModel.Password, registerModel.ConfPassword);

    this.submitted = true;
    this.CreateRequest();
  }

}
