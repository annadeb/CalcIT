import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ModalService } from '../modal/modal.service';

declare var require: any
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']

})
export class LoginComponent {
  imgG = require("../images/google.png");
  email: '';
  password: '';
  animal: string;
  name: string;
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: Router, private modalService: ModalService) {
  }
  onSave() {
    const formData = new FormData();
    formData.append('Email', this.email);
    formData.append('Password', this.password);
    this.httpClient.post<any>('api/account/login', formData).subscribe(
      response => {
        // console.log(response)
        // if (response.status === null) {
        console.log(response);
        localStorage.setItem('token', response.token);
        localStorage.setItem('userid',response.userid);
        this.route.navigate(['department']);

  
        // this.httpClient.get<UserRole>('api/admin/GetUserRoles?userId=' + response.userid).subscribe(role => {
        //   if(role.roles.result.indexOf('Admin')===0){
        //     this.route.navigate(['admin-view']);
        //   }
        //   if(role.roles.result.indexOf('NotActive')===0){
        //     this.route.navigate(['forbidden-view']);
        //   }

        //   if(role.roles.result.indexOf('Doctor')===0){
        //     this.route.navigate(['department']);
        //   }
        // }, error => console.error(error));
        
      },
      error => {
        // if (error.status === null) {
        // console.log(error);
        // this.route.navigate(['department']);
        // localStorage.setItem('token', error.error.text);
        // }
        // else {
        alert('Niepoprawne dane. Spróbuj jeszcze raz.'); console.log(error);
        // };
      });
  }


  onLoginG() {
    window.open('https://localhost:44353/api/Account/Google', '_blank');
    //  this.httpClient.get<any>('api/account/google').subscribe(res=>{console.log(res)}, err=>{console.log(err)})
  }
  onKeyE(event: any) {
    this.email = event.target.value;
  }
  onKeyP(event: any) {
    this.password = event.target.value;
  }

  openModal(id: string) {
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
  }
}
interface UserRole {
  user: string;
  roles: Roles;
};
interface Roles {
  result: string[];
}