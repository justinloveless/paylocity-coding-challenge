import {Component, OnInit} from '@angular/core';
import {EmployeeDependant} from "../../../models/employee-dependant";
import {RelationshipTypes} from "../../../models/relationship-types";

@Component({
  selector: 'app-remove-dependant',
  templateUrl: './remove-dependant.component.html',
  styleUrls: ['./remove-dependant.component.scss']
})
export class RemoveDependantComponent implements OnInit {
  dependantToRemove: EmployeeDependant = {
    dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child

  }
  constructor() { }

  ngOnInit(): void {
  }

  removeDependant() {
    alert("Not implemented yet")
  }

}
