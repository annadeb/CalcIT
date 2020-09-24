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
       http.get<Department[]>('api/departments/get').subscribe(result => {
      this.Departments = result;
      console.log(result);
    }, error => {
      console.error(error)
    });
  }
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
     
      this.token = params['token'];
    });
    console.log(localStorage.getItem('userid'))
    localStorage.setItem('display-button','true');

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