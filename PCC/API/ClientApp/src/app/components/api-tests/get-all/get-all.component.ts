import { Component, OnInit } from '@angular/core';
import {Employee} from "../../../models/employee";
import {EmployeeService} from "../../../services/employee.service";

@Component({
  selector: 'app-get-all',
  templateUrl: './get-all.component.html',
  styleUrls: ['./get-all.component.scss']
})
export class GetAllComponent implements OnInit {
  employees: Employee[] = [];
  isLoading: boolean = false;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
  }

  getAllEmployees(){
    this.isLoading = true;
    this.employees = []
    this.employeeService.getAll().subscribe(results => {
      this.employees = results;
      this.isLoading = false;
    })
  }

}
