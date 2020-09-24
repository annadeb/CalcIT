import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent{
  token:string='';
  Users: User[] = [];
  http: HttpClient;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute ) {
    this.http = http;
    http.get<User[]>('api/admin/GetUsers').subscribe(result => {
      this.Users = result;
      for (let index = 0; index < this.Users.length; index++) {
        http.get<UserRole>('api/admin/GetUserRoles?userId='+ this.Users[index].id ).subscribe(role => {
          this.Users[index].Status = role.roles.result.toString();
        }, error => console.error(error));
    }}, error => console.error(error));
    }    
    selectedOption: string;  
    options = [
      { name: "NotActive", value: 1 },
      { name: "Doctor", value: 2 }
    ]
  ngOnInit() {
    this.activatedRoute.queryParams.subscribe((params) => {
        console.log(params['token']); this.token=params['token'];
    });
    localStorage.setItem('display-button','true');
  }
  public submit(id: number) {
    console.log(this.selectedOption);
    var sel = document.getElementById(id.toString()) as HTMLSelectElement;
var text= sel.options[sel.selectedIndex].text;
console.log(text)
    console.log(id);
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
      this.http.post<any>('api/admin/SpecifyUserRole?userId='+id+'&role='+text, JSON, httpOptions).subscribe(
        (res) => {  if(res.status==200){alert('Przypisanie roli przebiegło pomyślnie');} 
        else{alert('Coś poszło nie tak. Sprawdź w logach'), console.log(res)}},
          error => {  if(error.status==200){alert('Przypisanie roli przebiegło pomyślnie');} 
          else{alert('Coś poszło nie tak. Sprawdź w logach'); console.log(error)}
      });
      window.location.reload();
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