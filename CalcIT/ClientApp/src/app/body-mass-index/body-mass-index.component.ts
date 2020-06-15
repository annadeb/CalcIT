import { Component,Inject, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';


@Component({
  selector: 'app-body-mass-index',
  templateUrl: './body-mass-index.component.html',
  styleUrls: ['./body-mass-index.component.css']
})
export class BodyMassIndexComponent  {
  http: HttpClient
  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) { 
    console.log(route.snapshot.params['patient_id'])

  }

  // addBMI (bmi: Calculation): Observable<Calculation> {
  //   /*this.http.post<Calculation>('api/BodyMassIndex/PostBMI', { doctor_id: 1, result:"28" }).subscribe(data => {
  //   this.patient_id = data.patient_id;})*/
  //    return this.http.post<Calculation>('api/BodyMassIndex/PostBMI', bmi)
  //    /* .pipe(
  //       catchError(this.handleError)
  //     ); */
  //}
  /* private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
    // A client-side or network error occurred. Handle it accordingly.
    console.error('An error occurred:', error.error.message);
  } else {
    // The backend returned an unsuccessful response code.
    // The response body may contain clues as to what went wrong,
    console.error(
      `Backend returned code ${error.status}, ` +
      `body was: ${error.error}`);
  }
  // return an observable with a user-facing error message
  return throwError(
    'Something bad happened; please try again later.');
}; */
}
interface Calculation {
    patient_id: number;
    doctor_id: number;
    calculation_date: Date;
    calculation_data:string;
    calculation_type:string;
    result: string;
}