import {Component, Inject, OnInit} from '@angular/core';
import {Employee} from "../../../models/employee";
import {Form, FormArray, FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {EmployeeService} from "../../../services/employee.service";

@Component({
  selector: 'app-add-employee-modal',
  templateUrl: './add-employee-modal.component.html',
  styleUrls: ['./add-employee-modal.component.scss']
})
export class AddEmployeeModalComponent implements OnInit {
  employee: Employee = {
    dependants: [], employeeId: 0, firstName: "", lastName: "", salary: 52000
  }
  nameFormGroup!: FormGroup;
  salaryFormGroup!: FormGroup;
  dependantsFormGroup!: FormGroup;


  constructor(private fb: FormBuilder,
  private employeeService: EmployeeService,
  private dialogRef: MatDialogRef<AddEmployeeModalComponent>,
  @Inject(MAT_DIALOG_DATA) data: any) { }

  ngOnInit(): void {
    this.nameFormGroup = this.fb.group({
      firstNameCtrl: ['', Validators.required],
      lastNameCtrl: ['', Validators.required]
    });
    this.salaryFormGroup = this.fb.group({
      salaryCtrl: ['', Validators.required]
    });
    this.dependantsFormGroup = this.fb.group({
      dependants: this.fb.array([])
    });
  }

  get firstName(){
    return this.nameFormGroup.controls["firstNameCtrl"] as FormControl;
  }

  get lastName(){
    return this.nameFormGroup.controls["lastNameCtrl"] as FormControl;
  }

  get salary() {
    return this.salaryFormGroup.controls["salaryCtrl"] as FormControl;
  }

  get dependants(){
    return this.dependantsFormGroup.controls["dependants"] as FormArray;
  }

  get dependantsControls() {
    return this.dependants.controls as FormGroup[];
  }

  submitEmployee(){
    this.employee.firstName = this.firstName?.value;
    this.employee.lastName = this.lastName?.value;
    this.employee.salary = this.salary?.value;
    this.employee.dependants = (this.dependants.controls as FormGroup[]).map(ctrl => ctrl.value);

    this.employeeService.hire(this.employee).subscribe(() => {
      this.dialogRef.close({
        success: true
      })
    }, error => {
      this.dialogRef.close({
        success: false,
        error: error
      })
    });
  }

  addDependantForm(){
    const dependantForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required]
    })

    this.dependants.push(dependantForm);
  }

  removeDependantForm(dependantIndex: number){
    this.dependants.removeAt(dependantIndex);
  }
}
