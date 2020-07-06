import { Component,Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
})
export class PatientComponent {

  Patients: Patient[] = [];
  patient;
    route: any;
    
  constructor(http: HttpClient, route: ActivatedRoute) {
    http.get<Patient[]>('api/Patients/get_patientInfo/' + route.snapshot.params['patient_id']).subscribe(result => {
      this.Patients = result;
      console.log(result)
      console.log('api/Patients/get_patientInfo/' + route.snapshot.params['patient_id'])
    }, error => console.error(error));
  }

}

interface Patient {
 patient_id: number;
  PESEL: number;
  Name: string;
  Surname: string;
  department_id: number;
}
