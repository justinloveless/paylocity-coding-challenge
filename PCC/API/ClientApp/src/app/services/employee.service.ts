import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Employee} from "../models/employee";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll(){
    console.log(this.baseUrl)
    return this.http.get<Employee[]>(this.baseUrl + 'employee');
  }

  getOne(employeeId: number){
    return this.http.get<Employee>(this.baseUrl + 'employee/' + employeeId);
  }

  hire(employee: Employee){
    return this.http.post(this.baseUrl + 'employee', employee);
  }

  fire(employeeId: number){
    return this.http.delete(this.baseUrl + 'employee/' + employeeId);
  }

  updateSalary(employeeId: number, salary: number){
    return this.http.put(this.baseUrl + 'employee/' + employeeId, {}, {
      params: {
        salary: salary
      }
    })
  }


}
