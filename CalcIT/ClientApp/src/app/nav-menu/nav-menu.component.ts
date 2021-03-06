import { Component } from '@angular/core';
declare var require: any
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  get user(): any {
    let temp;
    if (localStorage.getItem('display-button') === 'true') { temp = 'Wyloguj' }
    else { temp = '' }
    return temp;
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  imgname = require("../images/logo.png");

}
