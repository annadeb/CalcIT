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
response => {  if(response.status==200){this.route.navigate(['department']); localStorage.setItem('token',response.error.text);} 
else{alert('Niepoprawne dane. Spróbuj jeszcze raz.')};
},
error => { if(error.status==200){this.route.navigate(['department']); localStorage.setItem('token',error.error.text);} 
else{alert('Niepoprawne dane. Spróbuj jeszcze raz.')};
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
