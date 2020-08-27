import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent{
  Users: User[] = [
    {    user_id: 1, Name: 'Adam', Surname:'Kowalski', Status:'Nieaktywny'},
    {user_id: 2, Name: 'Anna', Surname:'Radecka', Status:'Lekarz'},
    {user_id: 3, Name: 'Karol', Surname:'Woźniak', Status:'Nieaktywny'},
    {user_id: 4, Name: 'Katarzyna', Surname:'Nowak', Status:'Administrator'}];

  constructor() { }


}
interface User {
  user_id: number;
   Name: string;
   Surname: string;
   Status: string;
 }