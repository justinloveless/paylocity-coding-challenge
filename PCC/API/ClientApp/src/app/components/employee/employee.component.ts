import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Employee} from "../../models/employee";
import {MatDialog} from "@angular/material/dialog";
import {
  EditEmployeeDependantsModalComponent
} from "../modals/edit-employee-dependants-modal/edit-employee-dependants-modal.component";
import {EditSalaryModalComponent} from "../modals/edit-salary-modal/edit-salary-modal.component";
import {EmployeeService} from "../../services/employee.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {EmployeeDetailsModalComponent} from "../modals/employee-details-modal/employee-details-modal.component";

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  @Input() employee!: Employee;
  @Output() reloadRequested = new EventEmitter<void>();

  constructor(private dialog: MatDialog,
              private snackBar: MatSnackBar,
              private employeeService: EmployeeService) { }

  ngOnInit(): void {
  }

  openDependantsDialog(){
    const dialogRef = this.dialog.open(EditEmployeeDependantsModalComponent, {
      data: {
        employee: this.employee
      }
    })
    dialogRef.afterClosed().subscribe(result => {
      if (result && result.success){
        this.reloadRequested.emit()
      }
    })
  }

  editSalaryDialog(){
    const dialogRef = this.dialog.open(EditSalaryModalComponent, {
      data: {
        employee: this.employee
      }
    })
    dialogRef.afterClosed().subscribe(result => {
        if (result && result.success && result.salary){
          this.employeeService.updateSalary(this.employee.employeeId, result.salary).subscribe(() => {
            this.reloadRequested.emit();
            this.snackBar.open("Salary updated", "Dismiss", {duration: 2000})
          })
        }
    })
  }

  fireEmployee(){
    // TODO: add a confirmation dialog
    this.employeeService.fire(this.employee.employeeId).subscribe(() => {
      this.reloadRequested.emit();
      this.snackBar.open("Employee fired", "Dismiss", {duration: 2000})
    })
  }

  viewDetails(){
    this.dialog.open(EmployeeDetailsModalComponent, {
      data: {
        employee: this.employee
      }
    })
  }

}
