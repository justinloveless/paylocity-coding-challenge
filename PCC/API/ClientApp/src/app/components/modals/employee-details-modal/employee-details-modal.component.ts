import {Component, Inject, OnInit} from '@angular/core';
import {Employee} from "../../../models/employee";
import {EmployeeDeductionDetails} from "../../../models/employee-deduction-details";
import {CalculateDeductionsService} from "../../../services/calculate-deductions.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-employee-details-modal',
  templateUrl: './employee-details-modal.component.html',
  styleUrls: ['./employee-details-modal.component.scss']
})
export class EmployeeDetailsModalComponent implements OnInit {
  employee!: Employee;
  employeeDeductionDetails!: EmployeeDeductionDetails;

  constructor(private calculateService: CalculateDeductionsService,
  private dialogRef: MatDialogRef<EmployeeDetailsModalComponent>,
  @Inject(MAT_DIALOG_DATA) data: any) {

    if (data && data.employee){
      this.employee = data.employee;
    }

  }

  ngOnInit(): void {
    this.calculateService.getDeductionsForEmployee(this.employee.employeeId).subscribe(result => {
      this.employeeDeductionDetails = result;
    }, error => {
      console.log(error)
    })
  }

  close(){
    this.dialogRef.close();
  }
}
