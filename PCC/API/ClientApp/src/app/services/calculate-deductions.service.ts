import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {EmployeeDeductionDetails} from "../models/employee-deduction-details";

@Injectable({
  providedIn: 'root'
})
export class CalculateDeductionsService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getTotalDeductions(){
    return this.http.get<number>(this.baseUrl + 'calculate/total');
  }

  getDeductionsForEmployee(id: number){
    return this.http.get<EmployeeDeductionDetails>(this.baseUrl + 'calculate/employee/' + id);
  }
}
