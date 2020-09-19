import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { ActivatedRoute, Router } from '@angular/router';
import { IfStmt } from '@angular/compiler';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
})
export class DepartmentsComponent {

  Departments: Department[] = [];
  token: string = '';
  http: any;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute, private route: Router) {
    this.http = http;
    http.get<UserRole>('api/admin/GetUserRoles?userId=' + localStorage.getItem('userid')).subscribe(role => {
      if(role.roles.result.indexOf('Admin')===0){
        this.route.navigate(['admin-view']);
      }
      // if(role.roles.result.indexOf('NotActive')===0){
      //   this.route.navigate(['forbidden-view']);
      // }
         // if(role.roles.result.indexOf('Admin'))
    }, error => {console.error(error);        this.route.navigate(['forbidden-view']);  });
    console.log(localStorage.getItem('userid'))
    http.get<Department[]>('api/departments/get').subscribe(result => {
      this.Departments = result;
      console.log(result);
    }, error => {
      //  if (error.status === 403) { this.route.navigate(['forbidden-view']); }; 
      console.error(error)
    });
  }
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
      // console.log(params);
      // console.log(localStorage.getItem('token'))
      // console.log(params['token']);
      this.token = params['token'];
    });
    console.log(localStorage.getItem('userid'))

    // this.http.get<UserRole>('api/admin/GetUserRoles?userId='+ localStorage.getItem('user_id') ).subscribe(role => {
    // }, error => console.error(error));

  }
}
interface Department {
  department_id: number;
  Name: string;
}
interface UserRole {
  user: string;
  roles: Roles;
};
interface Roles {
  result: string[];
}