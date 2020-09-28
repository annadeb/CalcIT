import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login/login.component';
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
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { WaitingSpinner } from './common/waitingSpinner';
import { ModalModule } from './modal/modal.module';
import { AuditTrial } from './audit-trial/audit-trial.component';
import { ForbiddenView } from './forbidden-view/forbidden-view.component';
import { AdminView } from './admin-view/admin-view.component';
import { PatientAddComponent } from './patient-add/patient-add.component';
import { LoggedOutView } from './logged-out/logged-out-view.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    DepartmentsComponent,
    PatientsComponent,
    PatientComponent,
    ResultsComponent,
    BodyMassIndexComponent,
    RegistrationComponent,
    AdminPanelComponent,
   ChildrenDosesComponent,
    WaitingSpinner,
  AuditTrial,
ForbiddenView,
AdminView,
PatientAddComponent,
LoggedOutView  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ModalModule, 
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'department', component: DepartmentsComponent },
      { path: 'patients/:department_id', component: PatientsComponent },
      { path: 'patient/:patient_id', component: PatientComponent },
      { path: 'results/:patient_id', component: ResultsComponent },
      { path: 'body-mass-index/:patient_id', component: BodyMassIndexComponent },
     { path: 'children-doses/:patient_id', component: ChildrenDosesComponent },
      { path: 'registration', component: RegistrationComponent },
      { path: 'admin-panel', component: AdminPanelComponent },
      {path:'waiting-spinner',component:WaitingSpinner},
      {path:'audit-trial', component:AuditTrial},
      {path:'forbidden-view', component:ForbiddenView},
      {path:'admin-view', component:AdminView},
      {path:'patient-add/:department_id', component:PatientAddComponent},
      {path:'logged-out',component:LoggedOutView}
    ])
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }, AuthService,{provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } } ],
  bootstrap: [AppComponent]
})
export class AppModule { }
