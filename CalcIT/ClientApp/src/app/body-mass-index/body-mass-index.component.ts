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
  user_id:string="8d440e1c-afe5-42bd-91f6-ac6a74f90c9e";
  BMIs=[];
  http: HttpClient
  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute ) { 
    this.http=http;
    this.patient_id=activatedRoute.snapshot.params['patient_id'];
    //this.user_id=activatedRoute.snapshot.params['user_id'];
    console.log(this.patient_id);
    //console.log(this.user_id);
  }
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
        console.log(params['token']); this.token=params['token'];
    });}
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
    
   /* const formData = new FormData();
    formData.append('calculation_data', 'waga: '+ this.weight.toString() + ', wzrost: '+ this.height.toString());
   formData.append('result', ((Math.round((this.weight/(this.height*this.height))*100))/100).toString());
   const obj = {number: this.patient_id};
   //const blob = new Blob([JSON.stringify(obj, null, 2)], {type : 'application/json'});
   formData.append('patient_id', this.patient_id.toString());
   formData.append('calculation_date', new Date().toISOString());
   formData.append('calculation_type', "BMI");
   formData.append('user_id', "8d440e1c-afe5-42bd-91f6-ac6a74f90c9e");
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
  var json = JSON.stringify(object);*/
    var body = "\{\"calculation_data\": \"waga: "+this.weight+", wzrost: "+this.height+"\", \"result\": \""+((Math.round((this.weight/(this.height*this.height))*100))/100).toString()+"\", \"patient_id\": "+this.patient_id+",\"calculation_date\":\""+new Date().toISOString()+"\",\"calculation_type\":\"BMI\",\"user_id\":\""+this.user_id+"\"\}";

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
    this.http.post<any>('api/Calculation/PostCalculation', body, httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
  }
  
 
}