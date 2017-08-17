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

  getFeedbacks():void {
   this.feedbacksService.getFeedbacks()
          .then(feedbacks =>
          {this.feedbacks = feedbacks; console.log(this.feedbacks) });
}

  ngOnInit(): void {  
    this.getFeedbacks();
  }

  @Input() newFeedback: Feedback = new Feedback;

  likeClick(feed: Feedback): void {

    ++feed.AgreeCount;

    console.log(feed as any);

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks();})
          .catch(error => console.log(error));

  }

    dislikeClick(feed: Feedback): void {

    ++feed.DisagreeCount;

    console.log(feed as any);

    this.feedbacksService
          .updateFeedback(feed)
          .then(feedback => {this.getFeedbacks();})
          .catch(error => console.log(error));

  }

  goClick(): void {
    this.newFeedback.AdvertisementId = 1;
    this.feedbacksService
          .postFeedback(this.newFeedback)
          .then(feedback => {this.getFeedbacks();})
          .catch(error => console.log(error));

  }
}