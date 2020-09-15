import { Component,Inject } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
})
export class DepartmentsComponent {
  
  Departments: Department[] = [];
  token:string='';
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute,private route:Router ) {

    http.get<Department[]>('api/departments/get').subscribe(result => {
      this.Departments = result;
    }, error => {if(error.status===403){this.route.navigate(['forbidden-view']);};console.error(error)});
  }
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
        console.log(params['token']); this.token=params['token'];
    });
  }
}
interface Department {
  department_id: number;
  Name: string;
}
