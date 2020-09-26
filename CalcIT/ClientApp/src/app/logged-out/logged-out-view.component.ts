import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
declare var require: any

@Component({
    selector: 'logged-out-view',
    templateUrl: 'logged-out-view.component.html',
    styleUrls: ['./logged-out-view.component.css']
})
export class LoggedOutView {
    imgCancel = require("../images/cancel.png");
    ngOnInit() {
        localStorage.setItem('display-button', 'false');
    }

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: Router) {
    }
}
