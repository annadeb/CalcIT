import { HttpClient } from '@angular/common/http';
import {Component, Inject} from '@angular/core';
import { Router } from '@angular/router';

declare var require: any

@Component({
    selector: 'admin-view',
    templateUrl: 'admin-view.component.html',
    styleUrls:['./admin-view.component.css']
  })
  export class AdminView {
    // imgCancel= require("../images/cancel.png");
ngOnInit(){  localStorage.setItem('display-button','true');
}

constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route:Router){
  }
  }
  