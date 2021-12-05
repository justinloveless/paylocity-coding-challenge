import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import {Employee} from "../../../models/employee";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {EmployeeService} from "../../../services/employee.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-edit-salary-modal',
  templateUrl: './edit-salary-modal.component.html',
  styleUrls: ['./edit-salary-modal.component.scss']
})
export class EditSalaryModalComponent implements OnInit {
  employee!: Employee;
  salary!: number;
  form!: FormGroup;

  constructor(private fb: FormBuilder,
              private employeeService: EmployeeService,
              private dialogRef: MatDialogRef<EditSalaryModalComponent>,
              @Inject(MAT_DIALOG_DATA) data: any) {
    if (data !== null){
      if (data.employee !== null){
        this.employee = data.employee;
      }
    }
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      salaryCtrl: [this.employee.salary, Validators.required]
    })

  }

  save(){
    this.dialogRef.close({
      success: true,
      salary: this.form.controls["salaryCtrl"].value
    })
  }

  cancel(){
    this.dialogRef.close({
      success: false
    })
  }

}
