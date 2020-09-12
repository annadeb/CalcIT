import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DepartmentsComponent } from './department/department.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientComponent } from './patient/patient.component';
import { ResultsComponent } from './results/results.component';
import { BodyMassIndexComponent } from './body-mass-index/body-mass-index.component';
import { RegistrationComponent } from './registration/registration.component';
import { TokenInterceptor } from './common/tokenInterceptor';
import { AuthService } from './common/authService';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ChildrenDosesComponent } from './children-doses/children-doses.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    CounterComponent,
    FetchDataComponent,
    DepartmentsComponent,
    PatientsComponent,
   PatientComponent,
   ResultsComponent,
   BodyMassIndexComponent,
   RegistrationComponent,
   AdminPanelComponent,
   ChildrenDosesComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'department', component: DepartmentsComponent },
      { path: 'patients/:department_id', component: PatientsComponent },
     { path: 'patient/:patient_id', component: PatientComponent },
     { path: 'results/:patient_id', component: ResultsComponent },
     { path: 'body-mass-index/:patient_id', component: BodyMassIndexComponent },
     { path: 'children-doses/:patient_id', component: ChildrenDosesComponent },
     {path:'registration',component:RegistrationComponent},
     {path:'admin-panel',component:AdminPanelComponent}
    ])
  ],
  providers: [{provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true},AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
