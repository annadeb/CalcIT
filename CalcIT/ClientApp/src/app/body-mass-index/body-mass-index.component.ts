import { Component,Input ,Inject, OnInit,Pipe } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-body-mass-index',
   templateUrl: './body-mass-index.component.html',
   styleUrls: ['./body-mass-index.component.css']
})

export class BodyMassIndexComponent  {
  token:string='';
 height: number=180;
  weight: number=70;
  patient_id:number;
  user_id:string;
  BMIs=[];
  http: HttpClient
  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute ) { 
    this.http=http;
    this.patient_id=activatedRoute.snapshot.params['patient_id'];
    console.log(this.patient_id);
    this.user_id=localStorage.getItem('userid');
  }
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
        console.log(params['token']); this.token=params['token'];
    });
    localStorage.setItem('display-button','true');
  }
  public addWeight(weight:number){
    this.weight=weight;
  }
  public addHeight(height:number){
    this.height=height;
  }
  
  public calculate() {
    console.log(this.weight,this.height);
    console.log("BMI=" + this.weight/(this.height*this.height));
    this.BMIs=[];
    this.BMIs.push(((Math.round((this.weight/(this.height*this.height))*100))/100));
    var body = "\{\"calculation_data\": \"waga: "+this.weight+"kg, wzrost: "+this.height+"m\", \"result\": \""+((Math.round((this.weight/(this.height*this.height))*100))/100).toString()+"\", \"patient_id\": "+this.patient_id+",\"calculation_date\":\""+new Date().toISOString()+"\",\"calculation_type\":\"BMI\",\"user_id\":\""+this.user_id+"\"\}";

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
    this.http.post<any>('api/Calculation/PostCalculation', body, httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
  }
  
 
}