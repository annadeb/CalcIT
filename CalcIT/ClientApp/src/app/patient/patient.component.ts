import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
})
export class PatientComponent {

  Patient: Patient;
  patient;
  route: any;
  http: HttpClient;

  constructor(http: HttpClient, route: ActivatedRoute, private router: Router) {
    this.http = http;
    this.route = route;
    this.router = router;
    http.get<Patient>('api/Patients/get_patientInfo/' + route.snapshot.params['patient_id']).subscribe(result => {
      this.Patient = result;
      console.log(result)
      console.log(this.Patient.department_id)
    }, error => { console.error(error); 
      // router.navigate(['logged-out'])
     });
  }
  public deletePatient() {
    this.http.delete<any>('api/Patients/deletePatient/' + this.route.snapshot.params['patient_id']).subscribe(res => {
     if(res.status===200) {alert('Pomyślnie wypisano pacjenta'); this.router.navigate(['patients/' + this.Patient.department_id]);}

    }, err => { if(err.status===200) {alert('Pomyślnie wypisano pacjenta');this.router.navigate(['patients/' + this.Patient.department_id])}})
  
  }

}

interface Patient {
  birthdate: string
department: null
department_id: number
height:number
name: string
patient_id: number
pesel: number
registration_date: string
surname: string
weight: number
}
