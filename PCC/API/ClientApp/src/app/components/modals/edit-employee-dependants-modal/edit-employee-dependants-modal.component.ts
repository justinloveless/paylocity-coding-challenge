import {Component, Inject, OnInit} from '@angular/core';
import {FormArray, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {EmployeeService} from "../../../services/employee.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {Employee} from "../../../models/employee";
import {RelationshipTypes} from "../../../models/relationship-types";
import {DependantService} from "../../../services/dependant.service";
import {EmployeeDependant} from "../../../models/employee-dependant";
import {forkJoin, Observable} from "rxjs";

@Component({
  selector: 'app-edit-employee-dependants-modal',
  templateUrl: './edit-employee-dependants-modal.component.html',
  styleUrls: ['./edit-employee-dependants-modal.component.scss']
})
export class EditEmployeeDependantsModalComponent implements OnInit {

  dependantsFormGroup!: FormGroup;
  employee!: Employee;

  dependantsRemoved: number[] = [];
  relationshipTypes: string[] = [
    RelationshipTypes[RelationshipTypes.child],
    RelationshipTypes[RelationshipTypes.spouse]
  ]

  constructor(private fb: FormBuilder,
              private employeeService: EmployeeService,
              private dependantService: DependantService,
              private dialogRef: MatDialogRef<EditEmployeeDependantsModalComponent>,
              @Inject(MAT_DIALOG_DATA) data: any) {

    if (data && data.employee){
      this.employee = data.employee;
    }
  }

  ngOnInit(): void {
    this.dependantsFormGroup = this.fb.group({
      dependants: this.fb.array([])
    });
    this.employee.dependants.forEach(d => {
      this.addDependantForm(d.firstName, d.lastName, d.relationship, d.dependantId)
    })

  }

  get dependants(){
    return this.dependantsFormGroup.controls["dependants"] as FormArray;
  }

  get dependantsControls() {
    return this.dependants.controls as FormGroup[];
  }

  addDependantForm(defaultFirstName: string = '', defaultLastName: string = '',
                   defaultRelationship: RelationshipTypes = RelationshipTypes.child, dependantId: number = 0){
    const dependantForm = this.fb.group({
      dependantId: [dependantId],
      employeeId: [this.employee.employeeId, Validators.required],
      firstName: [defaultFirstName, Validators.required],
      lastName: [defaultLastName, Validators.required],
      relationship: [RelationshipTypes[defaultRelationship], Validators.required]
    })

    this.dependants.push(dependantForm);
  }

  removeDependantForm(dependantIndex: number){

    // check if the dependant we're about to remove has a non-zero id
    const dependant = this.dependantsControls[dependantIndex].value as EmployeeDependant;
    if (dependant.dependantId !== 0)
      this.dependantsRemoved.push(dependant.dependantId);
    this.dependants.removeAt(dependantIndex);

  }

  submitChanges(){
    // find all dependants with an id of zero. They should all be added
    const newDependants = this.dependantsControls
      .map(ctrl => {
        const value = ctrl.value
        // TODO: Need to find a better way to do this...
        const depRelationship = value.relationship == "child" ? RelationshipTypes.child : RelationshipTypes.spouse;
        const dependant: EmployeeDependant = {
          dependantId: value.dependantId,
          employeeId: value.employeeId,
          firstName: value.firstName,
          lastName: value.lastName,
          relationship: depRelationship
        }
        return dependant
      })
      .filter(dep => (dep as EmployeeDependant).dependantId == 0)

    const tasks$: Observable<Object>[] = [];
    newDependants.forEach(dep => {
      tasks$.push(this.dependantService.addDependant(dep))
    })
    // then delete all dependant ids based on the dependantsRemoved array
    this.dependantsRemoved.forEach(depId => {
      tasks$.push(this.dependantService.removeDependant(depId, this.employee.employeeId))
    })

    // wait for all tasks to finish or error out
    forkJoin(tasks$).subscribe((vals: any[]) => {
      // TODO: snackbar notification
      this.dialogRef.close({
        success: true
      })
    }, error => {
      this.dialogRef.close({
        success: false
      })
      console.log("Error while submitting dependant changes:", error)
    })
  }
}
