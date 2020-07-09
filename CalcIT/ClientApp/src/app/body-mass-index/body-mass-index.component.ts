import { Component,Input ,Inject, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';


@Component({
  selector: 'app-body-mass-index',
   templateUrl: './body-mass-index.component.html',
   styleUrls: ['./body-mass-index.component.css']
  
 /*  template: `
    <input #newHero
      (keyup.enter)="addHero(newHero.value)"
      (blur)="addHero(newHero.value); newHero.value='' ">

    <button (click)="addHero(newHero.value)">Add</button>

    <ul><li *ngFor="let hero of heroes">{{hero}}</li></ul>
  ` */
})

export class BodyMassIndexComponent  {
  heroes = ['Windstorm', 'Bombasto', 'Magneta', 'Tornado'];
  addHero(newHero: string) {
    if (newHero) {
      this.heroes.push(newHero);
    }
  }
 height: number=180;
  weight: number=70;
  patient_id:number;
  calc: Calculation=new Calculation();
  BMIs=[];
  http: HttpClient
  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) { 
    this.http=http;
    //console.log(route.snapshot.params['patient_id'])
    this.patient_id=route.snapshot.params['patient_id'];
    console.log(this.patient_id);
  }
  public addWeight(weight:number){
    this.weight=weight;
  }
  public addHeight(height:number){
    this.height=height;
  }
  
  public calculate() {
    console.log(this.weight,this.height);
    console.log("BMI=" + this.weight/(this.height^2));
    this.BMIs=[];
    this.BMIs.push(this.weight/(this.height^2));
    
    const formData = new FormData();
    formData.append('calculation_data', 'waga: '+ this.weight.toString() + 'wzrost: '+ this.height.toString());
   formData.append('result', (this.weight/(this.height^2)).toString());
   formData.append('calculation_date', Date.now.toString());
   formData.append('patient_id', this.patient_id.toString());
   formData.append('doctor_id', "1");
   console.log(formData)

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
   
    this.calc.patient_id = this.patient_id.toString();
    this.calc.doctor_id = "1";
    this.calc.result = (this.weight/(this.height^2)).toString();
    this.calc.calculation_data = 'waga: '+ this.weight.toString() + 'wzrost: '+ this.height.toString();
    this.calc.calculation_date = Date.now();


    this.http.post<Calculation>('api/Calculation/PostCalculation', JSON.stringify(formData), httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
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
interface BMI{
  height: number;
  weight: number;
}
class Calculation {
    patient_id: string;
    doctor_id: string;
    calculation_date: number;
    calculation_data:string;
    calculation_type:string;
    result: string;
}