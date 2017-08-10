import { Component, OnInit } from '@angular/core';
import { Feedback } from '../models/feedback';
import { FeedbackService } from '../services/feedback.service';
import { Router } from '@angular/router';

@Component({
  selector: 'feedback-root',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css'],
  providers: [FeedbackService]
})
export class FeedbackComponent implements OnInit {
  constructor(private router:Router, private feedbacksService: FeedbackService) { }
  title: string ='Feedbacks';
  
  feedbacks: String[];
  selectedFeedback:Feedback;

  getFeedbacks():void {
   this.feedbacksService.getFeedbacks().then(feedbacks =>
     {this.feedbacks = feedbacks; console.log(this.feedbacks) });
}

  ngOnInit(): void {  
    this.getFeedbacks();
  }
}