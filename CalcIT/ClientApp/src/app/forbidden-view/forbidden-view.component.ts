import { HttpClient } from '@angular/common/http';
import {Component, Inject} from '@angular/core';
import { Router } from '@angular/router';
declare var require: any

@Component({
    selector: 'forbbiden-view',
    templateUrl: 'forbidden-view.component.html',
    styleUrls: ['./forbidden-view.component.css']
  })
  export class ForbiddenView {
    imgCancel= require("../images/cancel.png");


constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route:Router){
  }
  }
  