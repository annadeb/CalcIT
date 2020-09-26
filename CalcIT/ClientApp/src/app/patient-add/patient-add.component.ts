import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { Component, Inject, OnInit } from '@angular/core';
import { ControlContainer, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { AppComponent } from '../app.component';

/*@NgModule({
  imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule
  ],
  declarations: [
      AppComponent
  ],
  bootstrap: [AppComponent]
})*/
@Component({
  selector: 'app-patient-add',
  templateUrl: './patient-add.component.html',
  styleUrls: ['./patient-add.component.css']
})
export class PatientAddComponent implements OnInit {

  department_id: number;
  token:string='';
  route: any;
  name;
  surname;
  pesel;
  birthdate;
  weight: number;
  height: number;
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, route: ActivatedRoute) {
    this.http = http;
      this.department_id = route.snapshot.params['department_id'];
      console.log(this.department_id)
  }
  onSubmit() {
    var body = "\{\"name\": \""+this.name+"\",\"surname\": \""+this.surname+"\",\"birthdate\": \""+this.birthdate+"\",\"pesel\":"+this.pesel+",\"department_id\":"+this.department_id+",\"weight\": "+this.weight+",\"height\":"+this.height+"\}";

   const httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
    this.http.post<any>('api/Patients/CreatePatient', body, httpOptions).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
      );
  }

  ngOnInit() {
    
  }
  public addName(name:number){
    this.name=name;
  }
  public addSurName(surname:number){
    this.surname=surname;
  }
  public addBirthDate(birthdate:number){
    this.birthdate=birthdate;
    console.log(this.birthdate)
  }
  public addPesel(pesel:number){
    this.pesel=pesel;
  }
  public addHeight(height:number){
    this.height=height;
  }


  public addWeight(weight:number){
    this.weight=weight;
    console.log(this.weight)
  }

}
