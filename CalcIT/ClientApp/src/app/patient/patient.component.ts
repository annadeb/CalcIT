import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
})
export class PatientComponent {

  Patients: Patient[] = [];
  patient;
  route: any;

  constructor(http: HttpClient, route: ActivatedRoute, private router: Router) {
    http.get<Patient[]>('api/Patients/get_patientInfo/' + route.snapshot.params['patient_id']).subscribe(result => {
      this.Patients = result;
      console.log(result)
    }, error => { console.error(error); router.navigate(['logged-out']) });
  }

}

interface Patient {
  patient_id: number;
  PESEL: number;
  Name: string;
  Surname: string;
  department_id: number;
}
