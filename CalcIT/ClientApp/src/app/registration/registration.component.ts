import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

email:'';
password:'';
constructor( private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route:Router) { 
}
  ngOnInit() {
 
  }
  onSave(){
    const formData = new FormData();
    formData.append('Email', this.email);
   formData.append('Password', this.password);
this.httpClient.post<any>('api/account/register', formData).subscribe(
response => {  if(response.status==200){alert('Rejestracja przebiegła pomyślnie. Przejdź do logowania'); this.route.navigateByUrl('');} 
else{alert('Niepoprawne dane. Spróbuj jeszcze raz.')}},
  error => {  if(error.status==200){alert('Rejestracja przebiegła pomyślnie. Przejdź do logowania'); this.route.navigateByUrl('');} 
  else{alert('Niepoprawne dane. Spróbuj jeszcze raz.')}
  });

  }
onKeyE(event:any)
{
  this.email =event.target.value;
}
onKeyP(event:any)
{
  this.password =event.target.value;
}
}
