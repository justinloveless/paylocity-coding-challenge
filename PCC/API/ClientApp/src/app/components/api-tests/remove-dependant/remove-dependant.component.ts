import {Component, OnInit} from '@angular/core';
import {EmployeeDependant} from "../../../models/employee-dependant";
import {RelationshipTypes} from "../../../models/relationship-types";
import {DependantService} from "../../../services/dependant.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-remove-dependant',
  templateUrl: './remove-dependant.component.html',
  styleUrls: ['./remove-dependant.component.scss']
})
export class RemoveDependantComponent implements OnInit {
  dependantToRemove: EmployeeDependant = {
    dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child

  }
  isLoading = false;

  constructor(private dependantService: DependantService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  reset(){
    this.isLoading = false;
    this.dependantToRemove = {
      dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child
    }
  }

  notify(message: string){
    this.snackBar.open(message, "Dismiss", {duration: 2000})
  }

  removeDependant() {
    this.isLoading = true;
    this.dependantService.removeDependant(this.dependantToRemove.dependantId, this.dependantToRemove.employeeId)
      .subscribe({
        next: () => {
          const removedId = this.dependantToRemove.dependantId.toString(); // saving old value as it will be reset
          this.reset();
          this.notify(`Dependant ${removedId} removed from employee
          ${this.dependantToRemove.employeeId}`)
        },
        error: err => {
          this.reset()
          this.notify(`Unable to remove dependant from employee`)
        }
      })

  }

}
