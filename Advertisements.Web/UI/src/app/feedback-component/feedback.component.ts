import { Component, OnInit, Input, NgZone } from '@angular/core';
import { Feedback } from '../models/feedback';
import { FeedbackService } from '../services/feedback.service';
import { Router, ActivatedRoute, Params } from '@angular/router';

import 'rxjs/add/operator/switchMap';
import { Subscription } from "rxjs/Subscription";

@Component({
  selector: 'feedback-root',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css'],
  providers: [FeedbackService]
})
export class FeedbackComponent implements OnInit {
  constructor(private router:Router, private feedbacksService: FeedbackService, private zone: NgZone, private route : ActivatedRoute) { }

  private id: number;
  title: string ='Feedbacks';
  private route$ : Subscription; 
  
  
  feedbacks: String[];
  selectedFeedback: Feedback;
  accessDenied : boolean;
  isButtonClicked : boolean;
  errorMessage : string;
  itemClicked : number;
  

  getFeedbacks(id):void {
   this.accessDenied = false;
   this.isButtonClicked = false;

   this.feedbacksService.getFeedbacks(id)
          .then(feedbacks =>
          {this.feedbacks = feedbacks});
}

  ngOnInit(): void {  
    this.route$ = this.route.params.subscribe(
     (params: Params) => {
       this.id = +params["id"];
       this.getFeedbacks(this.id);
     }
   );
    
  }

  @Input() newFeedback: Feedback = new Feedback;

  likeClick(feed: Feedback): void {

    feed.Agree = true;
    this.isButtonClicked = false;
    this.itemClicked = feed.Id;

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks(this.id);})
          .catch((res) => {this.showNotification(res.status, res._body) });

  }

    dislikeClick(feed: Feedback): void {

    feed.Agree = false;
    this.isButtonClicked = false;
    this.itemClicked = feed.Id;

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks(this.id);})
          .catch((res) => {this.showNotification(res.status, res._body) });

  }

  goClick(): void {
    this.newFeedback.AdvertisementId = this.id;
    this.isButtonClicked = true;
    this.feedbacksService
          .postFeedback(this.newFeedback)
          .then(feedback => {this.getFeedbacks(this.id); this.newFeedback.Text = '';})
          .catch((res) => {this.showNotification(res.status, res._body) });

  }

  ngOnDestroy() {
   if (this.route$) this.route$.unsubscribe();
 }

  showNotification(statusCode : string, response : string) : void {

      if (statusCode == "401")
      {
        this.accessDenied = true; 
        this.errorMessage = "You need to authorize"; 
      }  

      if (statusCode == "400")
      {
        switch (response)
        {
          case "101": 
            this.accessDenied = true;
            this.errorMessage = "You already voted";
          break;
          case "201": 
            this.accessDenied = true;
            this.errorMessage = "You already left a comment";
          break;
        } 
      }
 
  }

}
