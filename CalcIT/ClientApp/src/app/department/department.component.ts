import { Component,Inject } from '@angular/core';
import { HttpClient} from '@angular/common/http'

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
})
export class DepartmentsComponent {
  Departments: Department[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Department[]>(baseUrl + 'api/departments').subscribe(result => {
      this.Departments = result;
    }, error => console.error(error));
  }
}
interface Department {
  department_id: number;
  Name: string;
}
