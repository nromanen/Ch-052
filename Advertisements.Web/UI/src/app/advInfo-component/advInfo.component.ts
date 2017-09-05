import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Subscription } from "rxjs/Subscription";

import { Advertisement } from '../models/advertisement';

import { AdvertisementService } from '../services/advertisement.service';
@Component({
  selector: 'advInfo',
  templateUrl: './advInfo.component.html',
  styleUrls: ['./advInfo.component.css'],
  providers: [ AdvertisementService]
})

export class AdvInfoComponent implements OnInit, OnDestroy {
  constructor(private router: Router, private advertisementService: AdvertisementService, private route: ActivatedRoute) { }

  private id: number;
  private route$: Subscription;
  title: string = 'Info of advertisement: id =';
  source: string;

  advertisement: Advertisement = new Advertisement();

  ngOnInit() {
    this.route$ = this.route.params.subscribe(
      (params: Params) => {
        this.id = +params["id"];
      }
    );
    this.getAdvertisement(this.id);
    this.title += this.id;
  }

  ngOnDestroy() {
    if (this.route$) this.route$.unsubscribe();
  }
  getAdvertisement(id): void {
    this.advertisementService.getAdv(id).then(advertisement => { this.advertisement = advertisement; this.source = advertisement.Resources[0].Url; });
  }

}
