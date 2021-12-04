import { Component, OnInit } from '@angular/core';
import {Employee} from "../../../models/employee";
import {EmployeeService} from "../../../services/employee.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-get-one',
  templateUrl: './get-one.component.html',
  styleUrls: ['./get-one.component.scss']
})
export class GetOneComponent implements OnInit {
  employeeId: number = 0;
  employee!: Employee;
  isLoading = false;

  constructor(private employeeService: EmployeeService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  find(){
    this.isLoading = true;
    this.employeeService.getOne(this.employeeId).subscribe((result: Employee) => {
      this.isLoading = false;
      this.employee = result;
    }, error => {
      this.isLoading = false;
      this.snackBar.open(`could not find employee ${this.employeeId}`, '', {
        duration: 2000
      })
    })
  }

}
