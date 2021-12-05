import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {EmployeeDependant} from "../models/employee-dependant";

@Injectable({
  providedIn: 'root'
})
export class DependantService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addDependant(dependant: EmployeeDependant){
    return this.http.post(this.baseUrl + 'dependant', dependant)
  }

  removeDependant(dependantId: number, employeeId: number){
    return this.http.delete(this.baseUrl + 'dependant?dependantId=' + dependantId + '&employeeId=' + employeeId);
  }

}
