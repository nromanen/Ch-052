import { Component, OnInit, ElementRef, Input, ViewChild } from '@angular/core';
import { UserRegisterModel } from '../models/UserRegisterModel'
import { ReactiveFormsModule, FormBuilder, Validators, NgForm, FormGroup, FormControl } from '@angular/forms';
import { HttpModule, Response } from '@angular/http';
import { RegistrationService } from '../services/registration.service'
@Component({
  selector: 'file-upload',
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
  public formData: FormData;
  multiple: boolean = false;
  @ViewChild('fileInput') imgReference: ElementRef;

  GetImg() {
    let base64str: string;
    let reader: FileReader = new FileReader();
    reader.onloadend = (e) =>{
      base64str = reader.result;   
      this.registrService.base64textString = base64str; 
  }

    let inputEl: HTMLInputElement = this.imgReference.nativeElement;
    let fileCount: number = inputEl.files.length;
    this.formData = new FormData();
    if (fileCount > 0) {
      for (let i = 0; i < fileCount; i++) {
        this.formData.append('file[]', inputEl.files.item(i));
      }

      reader.readAsDataURL(this.formData.get('file[]') as File);
    }
  }

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


 
  public OnSubmit(registerModel: UserRegisterModel, isValid: boolean): void {
    this.registerModel = new UserRegisterModel(registerModel.Name, registerModel.Surname,
      registerModel.Email, registerModel.Password, registerModel.ConfPassword);

    this.submitted = true;
    this.CreateRequest();
  }

}
