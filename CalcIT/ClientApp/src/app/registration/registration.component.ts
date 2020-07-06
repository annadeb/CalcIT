import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

email:'aaa';
password:'bbb';

//http:HttpClient;
//uploadForm:FormGroup;

constructor( private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 


}
//constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,){}
  ngOnInit() {
    // this.uploadForm = this.formBuilder.group({
    //   profile: ['']
    // });
  }
  onSave(){
    //console.log(this.email)
    const formData = new FormData();
    formData.append('Email', this.email);
   formData.append('Password', this.password);
// console.log(formData)
// this.http.post<any>('api/account/register', formData).subscribe(
//   (res) => console.log(res),
//   (err) => console.log(err)
// );
// this.httpClient.post<any>('/api/account/register', formData).subscribe(
// (res) => console.log(res),
//   (err) => console.log(err)
// );

  }
onKeyE(event:any)
{
  this.email =event.target.value;
  console.log(event.target.value)
}
onKeyP(event:any)
{
  this.password =event.target.value;
}
}
