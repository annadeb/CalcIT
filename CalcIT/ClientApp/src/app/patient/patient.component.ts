import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
})
export class PatientsComponent {

 Patients: Patient[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Patient[]>(baseUrl + 'api/Patients').subscribe(result => {
      this.Patients = result;
    }, error => console.error(error));
  }
}
interface Patient {
  PatientID: number;
  PESEL: number;
  Name: string;
  Surname: string;
}
