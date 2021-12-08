import { Component, OnInit } from '@angular/core';
import {EmployeeService} from "../../../services/employee.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-update-salary',
  templateUrl: './update-salary.component.html',
  styleUrls: ['./update-salary.component.scss']
})
export class UpdateSalaryComponent implements OnInit {
  employeeId = 0;
  salary = 0;
  isLoading = false;

  constructor(private employeeService: EmployeeService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  updateSalary(){
    this.isLoading = true;
    this.employeeService.getOne(this.employeeId).subscribe(emp => {
      // found employee
      this.employeeService.updateSalary(this.employeeId, this.salary).subscribe(() => {
        const empId = this.employeeId.toString(); // save old values before resetting
        const salary = this.salary.toString();
        this.reset(`Salary of employee ${empId} updated to ${salary}`);
      }, error =>  {
        const empId = this.employeeId.toString(); // save old values before resetting
        const salary = this.salary.toString();
        this.reset(`Unable to update salary of employee ${empId} to ${salary}`);
      })
    }, error => {
      // did not find employee
      this.reset(`Employee not found`);
    })
  }

  reset(message: string | null){
    this.isLoading = false;
    this.employeeId = 0;
    this.salary = 0;
    if (message) {
      this.snackBar.open(message, "Dismiss",
        {
          duration: 2000
        })
    }
  }

}
