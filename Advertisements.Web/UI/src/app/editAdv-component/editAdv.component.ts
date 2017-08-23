import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { EditAdvService } from '../services/editAdv.service';
import { Subscription } from "rxjs/Subscription";

@Component({
  selector: 'editAdv',
  templateUrl: './editAdv.component.html',
  styleUrls: ['./editAdv.component.css'],
  providers: [EditAdvService]
})

export class EditAdvComponent implements OnInit, OnDestroy {
  constructor(private router: Router, private editAdvService: EditAdvService, private route: ActivatedRoute) { }

  private id: number;
  private route$: Subscription;
  title: string = 'Edit';

  advertisement: Advertisement = new Advertisement();

  ngOnInit() {
    this.route$ = this.route.params.subscribe(
      (params: Params) => {
        this.id = +params["id"];
      }
    );
    this.getAdvertisement(this.id)
  }

  ngOnDestroy() {
    if (this.route$) this.route$.unsubscribe();
  }

  getAdvertisement(id): void {
    this.editAdvService.getAdvertisement(id).then(advertisement => { this.advertisement = advertisement; console.log(this.advertisement) });
  }

  onSubmit(advertisement):void
  {
    this.editAdvService.editAdv(advertisement);
  }
}