import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'file-upload',
    template: `
    <div>
        <h2>Upload Image</h2>
        <input type="file" accept="image/*" (change)="upload($event)" #fileInput/> 
        </div>
        `
})
export class UploadFileComponent {
    multiple: boolean = false;
    //@ViewChild('fileInput') inputEl: ElementRef;

    // constructor(private http: Http) { }

    // upload() {
    //     let inputEl: HTMLInputElement = this.inputEl.nativeElement;
    //     let fileCount: number = inputEl.files.length;
    //     let formData = new FormData();
    //     if (fileCount > 0) {
    //         for (let i = 0; i < fileCount; i++) {
    //             formData.append('file[]', inputEl.files.item(i));
    //         }
    //         this.http
    //             .post('/api/Advertisement/upload', formData).subscribe(r => r);
    //     }
    // }
}