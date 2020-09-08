import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent{
  token:string='';
  Users: User[] = [];
   // {    id: '1', userName: 'Adam', Status:'Nieaktywny'},
   // {id: '2', userName: 'Anna', Status:'Lekarz'},
   // {id: '3', userName: 'Karol', Status:'Nieaktywny'},
   // {id: '4', userName: 'Katarzyna', Status:'Administrator'}];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute ) {

    http.get<User[]>('api/admin/GetUsers').subscribe(result => {
      this.Users = result;
      for (let index = 0; index < this.Users.length; index++) {
        http.get<UserRole>('api/admin/GetUserRoles?userId='+ this.Users[index].id ).subscribe(role => {
          this.Users[index].Status = role.roles.result.toString();
          console.log('ROLA!')
          console.log(role)
        }, error => console.error(error));
      console.log(result)
    }}, error => console.error(error));


    /*http.get<UserRole>('api/admin/GetUserRoles?userId='+  '8b5a7fa2-7edd-4591-827d-2eafc0a44569').subscribe(role => {
      console.log('ROLA!')
      console.log(role.roles.result[0])
    }, error => console.error(error));

    for (let index = 0; index < this.Users.length; index++) {
      http.get<UserRole>('api/admin/GetUserRoles?userId='+ this.Users[index].id ).subscribe(role => {
        this.Users[index].Status = role.roles.result.toString();
        console.log('ROLA!')
        console.log(role)
      }, error => console.error(error)); */
    }
  /*  this.Users.forEach(user => {
      
      http.get<UserRole>('api/admin/GetUserRoles/'+user.id.toString()).subscribe(role => {
        user.Status = role.roles;
        console.log('ROLA!'+role)
      }, error => console.error(error));
    });*/
    
  
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
        console.log(params['token']); this.token=params['token'];
    });
  }
}
interface User {
  id: string;
  userName: string;
   Status: string;
 }
 interface UserRole
 {
    user: string;
    roles: Roles;
 };

 interface Roles{
result: string[];
 }