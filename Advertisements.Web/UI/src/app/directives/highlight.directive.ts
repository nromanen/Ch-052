import { Directive, ElementRef, Input } from '@angular/core';

@Directive({ selector: '[myHighlight]',
             host: {
                 '(mouseenter)':'onMouseEnter()',
                 '(mouseleave)':'onMouseLeave()'
             } })
export class HighlightDirective {
    private el: HTMLElement;
    private _color = '#f5f5f5';
    constructor(el: ElementRef) { this.el = el.nativeElement; }
    
    onMouseEnter() { this.highlight(this._color); }
    onMouseLeave() { this.highlight(null); }
  
     private highlight(color:string) {
        
      this.el.style.backgroundColor = color;
    }
}