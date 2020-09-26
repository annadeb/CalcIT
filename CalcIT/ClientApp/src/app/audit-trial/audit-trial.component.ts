import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'audit-trial',
  templateUrl: 'audit-trial.component.html',
})
export class AuditTrial implements OnInit {
  Audit: Audit[] = [];
  Users: User[] = [];
  Users_name: string[] = [];
  http: HttpClient;
  router:Router;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
    this.http = http;
this.router=router
    console.log(this.Users_name)
  }
  async ngOnInit(): Promise<void> {
    await this.http.get<Audit[]>('api/admin/getfullAudit').subscribe(result => {
      this.Audit = result.reverse(); console.log(result)
    }, error => { console.error(error); this.router.navigate(['logged-out'])});
    await this.http.get<User[]>('api/admin/getUsers').subscribe(result => {
      this.Users = result; console.log(result)
    }, error => console.error(error));
    console.log(this.Audit)

  }

  ngDoCheck() {
    for (let i = 0; i < this.Audit.length; i++) {
      let temp = this.Audit[i].date_time.slice(0, 19).replace("T", " ");
      this.Audit[i].date_time = temp;
    }
    for (let i = 0; i < this.Audit.length; i++) {
      for (let j = 0; j < this.Users.length; j++) {
        if (this.Audit[i].user_id === this.Users[j].id) {
          this.Users_name.push(this.Users[j].userName)
        }

      }
    }
    localStorage.setItem('display-button', 'true');
    console.log(this.Users_name[1])
  }

}
interface Audit {
  at_id: Number,
  date_time: string,
  events: string,
  status_code: Number,
  user_id: string
}
interface User {
  id: string;
  userName: string;
  Status: string;
}
