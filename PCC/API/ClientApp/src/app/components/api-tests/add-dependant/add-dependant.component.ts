import {Component, OnInit} from '@angular/core';
import {EmployeeDependant} from "../../../models/employee-dependant";
import {RelationshipTypes} from "../../../models/relationship-types";
import {DependantService} from "../../../services/dependant.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-add-dependant',
  templateUrl: './add-dependant.component.html',
  styleUrls: ['./add-dependant.component.scss']
})
export class AddDependantComponent implements OnInit {
  dependantToAdd: EmployeeDependant = {
    dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child
  }
  isLoading = false;

  constructor(private dependantService: DependantService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  reset(){
    this.isLoading = false;
    // reset model when complete
    this.dependantToAdd = {
      dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child
    }
  }

  notify(message: string){
    this.snackBar.open(message, "Dismiss", {duration: 2000});
  }

  addDependant(){
    this.isLoading = true;
    this.dependantService.addDependant(this.dependantToAdd).subscribe(() => {
      const empId = this.dependantToAdd.employeeId.toString(); // saving old value
      this.reset();
      this.notify(`Dependant added to employee ${empId}`)
    }, error => {
      this.reset();
      this.notify(`Unable to add dependant to employee`);
    })

  }

}
