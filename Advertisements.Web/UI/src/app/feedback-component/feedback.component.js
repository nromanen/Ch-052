"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const feedback_1 = require("../models/feedback");
const feedback_service_1 = require("../services/feedback.service");
const router_1 = require("@angular/router");
require("rxjs/add/operator/switchMap");
let FeedbackComponent = class FeedbackComponent {
    constructor(router, feedbacksService, zone) {
        this.router = router;
        this.feedbacksService = feedbacksService;
        this.zone = zone;
        this.title = 'Feedbacks';
        this.newFeedback = new feedback_1.Feedback;
    }
    getFeedbacks() {
        this.feedbacksService.getFeedbacks()
            .then(feedbacks => { this.feedbacks = feedbacks; console.log(this.feedbacks); });
    }
    ngOnInit() {
        this.getFeedbacks();
    }
    likeClick(feed) {
        ++feed.AgreeCount;
        console.log(feed);
        this.feedbacksService
            .updateFeedback(feed)
            .then(feedback => { this.getFeedbacks(); })
            .catch(error => console.log(error));
    }
    dislikeClick(feed) {
        ++feed.DisagreeCount;
        console.log(feed);
        this.feedbacksService
            .updateFeedback(feed)
            .then(feedback => { this.getFeedbacks(); })
            .catch(error => console.log(error));
    }
    goClick() {
        this.newFeedback.AdvertisementId = 1;
        this.feedbacksService
            .postFeedback(this.newFeedback)
            .then(feedback => { this.getFeedbacks(); })
            .catch(error => console.log(error));
    }
};
__decorate([
    core_1.Input(),
    __metadata("design:type", feedback_1.Feedback)
], FeedbackComponent.prototype, "newFeedback", void 0);
FeedbackComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'feedback-root',
        templateUrl: './feedback.component.html',
        styleUrls: ['./feedback.component.css'],
        providers: [feedback_service_1.FeedbackService]
    }),
    __metadata("design:paramtypes", [router_1.Router, feedback_service_1.FeedbackService, core_1.NgZone])
], FeedbackComponent);
exports.FeedbackComponent = FeedbackComponent;
//# sourceMappingURL=feedback.component.js.map