import {Directive, OnInit, Input, Attribute} from '@angular/core';
import {Http} from '@angular/http';
import {DomSanitizer, ɵBROWSER_SANITIZATION_PROVIDERS} from '@angular/platform-browser';

@Directive({
  selector: '[userIdForImg]',
  providers: [ɵBROWSER_SANITIZATION_PROVIDERS],
  host: {
    '[src]': 'sanitizer.bypassSecurityTrustUrl(imageData)'
  }
})
export class UserAvatarDirective  {
  private imageData: any;
  private GetUserAvatarUrl: string;  

  @Input() set userIdForImg(userId:string)
  {
    this.GetImage(userId);
  }
  
  constructor(private http: Http,
              private sanitizer: DomSanitizer, ) 
              {
                this.GetUserAvatarUrl = "/api/Account/getavatar/";
              }
  

  GetImage(userId: string):void {  
    let id = userId;      
    this.http.get(this.GetUserAvatarUrl + id)
      .map(image => image.text())
      .subscribe(
        data => {
          this.imageData = 'data:image/png;base64,' + data;
        }
      );
  }
}