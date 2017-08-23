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
    constructor(router, feedbacksService, zone, route) {
        this.router = router;
        this.feedbacksService = feedbacksService;
        this.zone = zone;
        this.route = route;
        this.title = 'Feedbacks';
        this.newFeedback = new feedback_1.Feedback;
    }
    getFeedbacks(id) {
        this.feedbacksService.getFeedbacks(id)
            .then(feedbacks => { this.feedbacks = feedbacks; });
        this.accessDenied = false;
        this.isButtonClicked = false;
    }
    ngOnInit() {
        this.route$ = this.route.params.subscribe((params) => {
            this.id = +params["id"];
        });
        this.getFeedbacks(this.id);
    }
    likeClick(feed) {
        feed.Agree = true;
        this.isButtonClicked = false;
        this.itemClicked = feed.Id;
        this.feedbacksService
            .updateFeedback(feed)
            .then(feedback => { this.getFeedbacks(this.id); })
            .catch((res) => { this.showNotification(res.status, res._body); });
    }
    dislikeClick(feed) {
        feed.Agree = false;
        this.isButtonClicked = false;
        this.itemClicked = feed.Id;
        this.feedbacksService
            .updateFeedback(feed)
            .then(feedback => { this.getFeedbacks(this.id); })
            .catch((res) => { this.showNotification(res.status, res._body); });
    }
    goClick() {
        this.newFeedback.AdvertisementId = 1;
        this.isButtonClicked = true;
        this.feedbacksService
            .postFeedback(this.newFeedback)
            .then(feedback => { this.getFeedbacks(this.id); this.newFeedback.Text = ''; })
            .catch((res) => { this.showNotification(res.status, res._body); });
    }
    ngOnDestroy() {
        if (this.route$)
            this.route$.unsubscribe();
    }
    showNotification(statusCode, response) {
        if (statusCode == "401") {
            this.accessDenied = true;
            this.errorMessage = "You need to authorize";
        }
        if (statusCode == "400") {
            switch (response) {
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
};
__decorate([
    core_1.Input(),
    __metadata("design:type", feedback_1.Feedback)
], FeedbackComponent.prototype, "newFeedback", void 0);
FeedbackComponent = __decorate([
    core_1.Component({
        moduleId: module.id.toString(),
        selector: 'feedback-root',
        templateUrl: './feedback.component.html',
        styleUrls: ['./feedback.component.css'],
        providers: [feedback_service_1.FeedbackService]
    }),
    __metadata("design:paramtypes", [router_1.Router, feedback_service_1.FeedbackService, core_1.NgZone, router_1.ActivatedRoute])
], FeedbackComponent);
exports.FeedbackComponent = FeedbackComponent;
//# sourceMappingURL=feedback.component.js.map