import { Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { Advertisement } from '../models/advertisement';
import { CreateAdvService } from '../services/createAdv.service';
import { Subscription } from "rxjs/Subscription";

@Component({
  selector: 'createAdv',
  templateUrl: './createAdv.component.html',
  styleUrls: ['./createAdv.component.css'],
  providers: [CreateAdvService]
})

export class CreateAdvComponent implements OnInit {
  constructor(private router: Router, private createAdvService: CreateAdvService, private route: ActivatedRoute) { }

  advertisement: Advertisement = new Advertisement();

  ngOnInit() {
  }

  onSubmit(advertisement):void
  {
    this.createAdvService.createAdv(advertisement);
  }
}