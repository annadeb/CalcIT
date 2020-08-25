import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  email:'';
password:'';
constructor( private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route:Router) { 
}
onSave(){
  const formData = new FormData();
  formData.append('Email', this.email);
 formData.append('Password', this.password);
this.httpClient.post<any>('api/account/login', formData).subscribe(
response => {  console.log(response); this.route.navigate(['department'], {queryParams: {token:response.error.text}}); localStorage.setItem('token',response.error.text);
},
error => {  console.log(error); localStorage.setItem('token',error.error.text); this.route.navigate(['department']);
});

}
  onKeyE(event:any)
{
  this.email =event.target.value;
  console.log(this.email)
}
onKeyP(event:any)
{
  this.password =event.target.value;
}
}
