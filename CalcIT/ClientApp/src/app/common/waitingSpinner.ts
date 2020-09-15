import { HttpClient } from '@angular/common/http';
import {Component, Inject} from '@angular/core';
import { Router } from '@angular/router';
import { interval } from 'rxjs';
import { takeWhile } from 'rxjs/operators';

@Component({
    selector: 'waiting-spinner',
    templateUrl: 'waitingSpinner.html',
  })
  export class WaitingSpinner {

constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route:Router){
    function opensnack(text: string) : void {
      console.log(text);
      httpClient.get<any>('api/account/google').subscribe(
        response => { console.log(response);        },
        error => { console.log(error)        });
    }
    
    setInterval(opensnack, 1000);
  }
  }
  