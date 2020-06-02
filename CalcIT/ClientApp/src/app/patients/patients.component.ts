import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
})
export class PatientsComponent {

  Patients: Patient[] = [];
  patient;
    route: any;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) {
    http.get<Patient[]>('api/Patients/GetPatients/' + route.snapshot.params['department_id']).subscribe(result => {
      this.Patients = result;
      console.log('api/Patients/GetPatients/' + route.snapshot.params['department_id'])
    }, error => console.error(route.snapshot.params['department_id']));
  }
 
}
interface Patient {
 patient_id: number;
  PESEL: number;
  Name: string;
  Surname: string;
  department_id: number;
}
