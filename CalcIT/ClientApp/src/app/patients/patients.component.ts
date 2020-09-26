import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
})
export class PatientsComponent {
  Patients: Patient[] = [];
  patient;
  department_id: number;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute,private router: Router) {
    http.get<Patient[]>('api/Patients/GetPatients/' + route.snapshot.params['department_id']).subscribe(result => {
      this.Patients = result;
      this.department_id = route.snapshot.params['department_id'];
      console.log('api/Patients/GetPatients/' + route.snapshot.params['department_id'])
    }, error => {console.error(route.snapshot.params['department_id']);      router.navigate(['logged-out']);
  });
  }
 
}
interface Patient {
 patient_id: number;
  PESEL: number;
  Name: string;
  Surname: string;
  department_id: number;
}
