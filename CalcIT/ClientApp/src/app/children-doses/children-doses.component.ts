import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-children-doses',
  templateUrl: './children-doses.component.html',
  styleUrls: ['./children-doses.component.css']
})
export class ChildrenDosesComponent implements OnInit {

  token:string='';
  weight: number=5;
   dose: number=0.05;
   patient_id:number;
   user_id:string;
   Doses=[];
   http: HttpClient
   constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute ) { 
     this.http=http;
     this.patient_id=activatedRoute.snapshot.params['patient_id'];
     this.user_id=localStorage.getItem('userid');
     //this.user_id=activatedRoute.snapshot.params['user_id'];
     console.log(this.patient_id);
     //console.log(this.user_id);
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
   public addDose(dose:number){
     this.dose=dose;
   }
   public calculate() {
    console.log("waga: "+this.weight,"dawka: "+this.dose);
    this.Doses=[];
    var dose1=(this.dose*this.weight)/(70);
    var calculatedDose =((Math.round(((this.dose*this.weight)/(70))*10000))/10000);
    console.log(dose1, calculatedDose);
    this.Doses.push(calculatedDose);

    var body = "\{\"calculation_data\": \"waga: "+this.weight+"kg, dawka: "+this.dose+"g\", \"result\": \""+calculatedDose.toString()+"g\", \"patient_id\": "+this.patient_id+",\"calculation_date\":\""+new Date().toISOString()+"\",\"calculation_type\":\"Dawka leku\",\"user_id\":\""+this.user_id+"\"\}";

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
    this.http.post<any>('api/Calculation/PostCalculation', body, httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
  }
}
