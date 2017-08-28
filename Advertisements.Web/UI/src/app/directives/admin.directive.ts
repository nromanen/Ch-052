import { Directive, TemplateRef, ViewContainerRef, Input, OnInit } from '@angular/core';

@Directive({ selector: '[admin]' })
export class AdminDirective {

    constructor(private templateRef: TemplateRef<any>,
        private viewContainer: ViewContainerRef) { }

    @Input() set admin(roleOnTag: string) {
        if (roleOnTag ==  localStorage.getItem('role')) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }

}