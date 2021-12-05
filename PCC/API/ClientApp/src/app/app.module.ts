import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from "@angular/material/expansion";
import {MatButtonModule} from "@angular/material/button";
import {MatFormFieldModule} from "@angular/material/form-field";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatDialogModule} from "@angular/material/dialog";
import {HttpClient, HttpClientModule} from "@angular/common/http";
import {MatToolbarModule} from "@angular/material/toolbar";
import {TooltipModule} from "ngx-bootstrap/tooltip";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import { SummaryComponent } from './components/summary/summary.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { HeaderComponent } from './components/header/header.component';
import { ApiTestsComponent } from './components/api-tests/api-tests.component';
import { GetAllComponent } from './components/api-tests/get-all/get-all.component';
import { GetOneComponent } from './components/api-tests/get-one/get-one.component';
import { HireComponent } from './components/api-tests/hire/hire.component';
import { FireComponent } from './components/api-tests/fire/fire.component';
import { AddDependantComponent } from './components/api-tests/add-dependant/add-dependant.component';
import { RemoveDependantComponent } from './components/api-tests/remove-dependant/remove-dependant.component';
import {MatIconModule} from "@angular/material/icon";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import {CdkScrollableModule} from "@angular/cdk/scrolling";
import { UpdateSalaryComponent } from './components/api-tests/update-salary/update-salary.component';
import {MatListModule} from "@angular/material/list";
import {MatGridListModule} from "@angular/material/grid-list";
import {MatBadgeModule} from "@angular/material/badge";
import {MatCardModule} from "@angular/material/card";
import { AddEmployeeModalComponent } from './components/modals/add-employee-modal/add-employee-modal.component';
import { EditEmployeeDependantsModalComponent } from './components/modals/edit-employee-dependants-modal/edit-employee-dependants-modal.component';
import { EditSalaryModalComponent } from './components/modals/edit-salary-modal/edit-salary-modal.component';
import {MatStepperModule} from "@angular/material/stepper";
import {MatSelectModule} from "@angular/material/select";
import { EmployeeDetailsModalComponent } from './components/modals/employee-details-modal/employee-details-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SummaryComponent,
    EmployeeListComponent,
    EmployeeComponent,
    HeaderComponent,
    ApiTestsComponent,
    GetAllComponent,
    GetOneComponent,
    HireComponent,
    FireComponent,
    AddDependantComponent,
    RemoveDependantComponent,
    UpdateSalaryComponent,
    AddEmployeeModalComponent,
    EditEmployeeDependantsModalComponent,
    EditSalaryModalComponent,
    EmployeeDetailsModalComponent
  ],
    imports: [
        // BrowserModule,
        // AppRoutingModule,
        // BrowserAnimationsModule,
        // MatExpansionModule,
        // MatButtonModule,
        // MatFormFieldModule,
        // FormsModule,
        // MatInputModule,
        // MatDialogModule,
        // HttpClientModule,
        // MatToolbarModule,


        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatExpansionModule,
        TooltipModule.forRoot(),
        MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        MatDialogModule,
        MatSnackBarModule,
        MatIconModule,
        MatProgressSpinnerModule,
        CdkScrollableModule,
        MatListModule,
        MatGridListModule,
        MatBadgeModule,
        MatCardModule,
        MatStepperModule,
        MatSelectModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
