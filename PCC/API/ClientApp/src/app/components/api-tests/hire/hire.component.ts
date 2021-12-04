import { Component, OnInit } from '@angular/core';
import {Employee} from "../../../models/employee";
import {EmployeeService} from "../../../services/employee.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-hire',
  templateUrl: './hire.component.html',
  styleUrls: ['./hire.component.scss']
})
export class HireComponent implements OnInit {
  employeeToHire: Employee = {
    dependants: [], employeeId: 0, firstName: "", lastName: "", salary: 0
  }
  isLoading = false;

  constructor(private employeeService: EmployeeService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  hire(){
    this.isLoading = true;
    this.employeeService.hire(this.employeeToHire).subscribe(() => {
      this.isLoading = false;
      // reset model when complete
      this.employeeToHire = {
        dependants: [], employeeId: 0, firstName: "", lastName: "", salary: 0
      }
      this.snackBar.open(`employee ${this.employeeToHire.firstName} ${this.employeeToHire.lastName} hired`,
        '', {
        duration: 2000
      })
    })
  }

}
