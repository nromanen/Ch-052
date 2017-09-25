import { Directive, TemplateRef, ViewContainerRef, Input, OnInit } from '@angular/core';
import { ComcomService } from '../services/comcom.service';

import { Subscription } from 'rxjs/Subscription';

@Directive({ selector: '[admin]' })
export class AdminDirective {
    subscription: Subscription;

    constructor(private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef, private comcomService: ComcomService) {
        this.subscription = this.comcomService.getObservableRole().subscribe(str => {
            this.adminChecker(str);
        });
    }

    @Input() set admin(roleOnTag: string) {
        this.adminChecker(roleOnTag);
    }

    adminChecker(role: string): void {
        if (role == localStorage.getItem('role')) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }

}