import { Component, OnInit, Input, NgZone } from '@angular/core';
import { Feedback } from '../models/feedback';
import { FeedbackService } from '../services/feedback.service';
import { Router } from '@angular/router';

import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'feedback-root',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css'],
  providers: [FeedbackService]
})
export class FeedbackComponent implements OnInit {
  constructor(private router:Router, private feedbacksService: FeedbackService, private zone: NgZone) { }

  title: string ='Feedbacks';
  
  
  feedbacks: String[];
  selectedFeedback: Feedback;
  accessDenied : boolean;
  isButtonClicked : boolean;
  errorMessage : string;
  itemClicked : number;
  

  getFeedbacks():void {
   this.feedbacksService.getFeedbacks()
          .then(feedbacks =>
          {this.feedbacks = feedbacks});
}

  ngOnInit(): void {  
    this.getFeedbacks();
  }

  @Input() newFeedback: Feedback = new Feedback;

  likeClick(feed: Feedback): void {

    feed.Agree = true;
    this.isButtonClicked = false;
    this.itemClicked = feed.Id;

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks();})
          .catch((res) => {this.showNotification(res.status, res._body) });

  }

    dislikeClick(feed: Feedback): void {

    feed.Agree = false;
    this.isButtonClicked = false;
    this.itemClicked = feed.Id;

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks();})
          .catch((res) => {this.showNotification(res.status, res._body) });

  }

  goClick(): void {
    this.newFeedback.AdvertisementId = 1;
    this.isButtonClicked = true;
    this.feedbacksService
          .postFeedback(this.newFeedback)
          .then(feedback => {this.getFeedbacks(); this.newFeedback.Text = '';})
          .catch((res) => {this.showNotification(res.status, res._body) });

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