import { Component, OnInit } from '@angular/core';
import {EmployeeService} from "../../../services/employee.service";
import {F} from "@angular/cdk/keycodes";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-fire',
  templateUrl: './fire.component.html',
  styleUrls: ['./fire.component.scss']
})
export class FireComponent implements OnInit {
  employeeToFireId: number = 0;
  isLoading = false;

  constructor(private employeeService: EmployeeService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  fire(){
    this.isLoading = true;
    this.employeeService.fire(this.employeeToFireId).subscribe(() =>{
      this.isLoading = false;
      const idFired = this.employeeToFireId.toString(); // saving old value of id, as we'll be restting it
      this.employeeToFireId = 0; // reset model
      this.snackBar.open(`employee ${idFired} fired`, '', {
        duration: 2000
      })
    }, error => {
      this.isLoading = false;
      this.employeeToFireId = 0; // reset model
      this.snackBar.open(`could not fire employee ${this.employeeToFireId}`, '', {
        duration: 2000
      })
    })
  }

}
