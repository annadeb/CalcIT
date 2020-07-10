import { Component,Input ,Inject, OnInit,Pipe } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-body-mass-index',
   templateUrl: './body-mass-index.component.html',
   styleUrls: ['./body-mass-index.component.css']
})

export class BodyMassIndexComponent  {
 height: number=180;
  weight: number=70;
  patient_id:number;
  BMIs=[];
  http: HttpClient
  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) { 
    this.http=http;
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
    this.BMIs.push(Math.floor(this.weight/(this.height^2)));
    
    const formData = new FormData();
    formData.append('calculation_data', 'waga: '+ this.weight.toString() + ', wzrost: '+ this.height.toString());
   formData.append('result', Math.floor(this.weight/(this.height^2)).toString());
   formData.append('calculation_date', new Date().toISOString());
   formData.append('calculation_type', "BMI");
   formData.append('patient_id', this.patient_id.toString());
   formData.append('doctor_id', "1");
   console.log(formData)
   var object = {};
  formData.forEach((value, key) => {
      if(!Reflect.has(object, key)){
          object[key] = value;
          return;
      }
      if(!Array.isArray(object[key])){
          object[key] = [object[key]];    
      }
      object[key].push(value);
  });
  var json = JSON.stringify(object);

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
    this.http.post<any>('api/Calculation/PostCalculation', json, httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
  }
  
 
}