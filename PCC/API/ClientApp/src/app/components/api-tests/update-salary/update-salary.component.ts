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
    this.employeeService.updateSalary(this.employeeId, this.salary).subscribe(() => {
      this.reset(`Salary of employee ${this.employeeId} updated to ${this.salary}`);
    }, error =>  {
      this.reset(`Unable to update salary of employee ${this.employeeId} to ${this.salary}`);
    })
  }

  reset(message: string | null){
    this.isLoading = false;
    this.employeeId = 0;
    this.salary = 0;
    if (message) {
      this.snackBar.open(message, "",
        {
          duration: 2000
        })
    }
  }

}
