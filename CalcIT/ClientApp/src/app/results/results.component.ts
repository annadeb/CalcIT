import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css']
})
export class ResultsComponent {
  Results: Calculation[] = [];
  result;
  route: any;
  patient_id: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) {
    http.get<Calculation[]>('api/Patients/Get_PatientResults/' + route.snapshot.params['patient_id']).subscribe(result => {
      this.Results = result.reverse();
      this.Results.map(res => { res.calculation_date = res.calculation_date.slice(0, 19).replace("T", " ") })

      this.patient_id = route.snapshot.params['patient_id'];
    }, error => console.error(route.snapshot.params['patient_id']));
  }
  ngOnInit() {
    localStorage.setItem('display-button', 'true');
  }
}
interface Calculation {
  calculation_id: number;
  patient_id: number;
  user_id: number;
  calculation_date: string;
  calculation_data: string;
  calculation_type: string;
  result: string;
}