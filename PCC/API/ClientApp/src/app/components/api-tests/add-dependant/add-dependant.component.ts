import {Component, OnInit} from '@angular/core';
import {EmployeeDependant} from "../../../models/employee-dependant";
import {RelationshipTypes} from "../../../models/relationship-types";

@Component({
  selector: 'app-add-dependant',
  templateUrl: './add-dependant.component.html',
  styleUrls: ['./add-dependant.component.scss']
})
export class AddDependantComponent implements OnInit {
  dependantToAdd: EmployeeDependant = {
    dependantId: 0, employeeId: 0, firstName: "", lastName: "", relationship: RelationshipTypes.child
  }
  constructor() { }

  ngOnInit(): void {
  }

  addDependant(){
    alert("Not implemented yet")
  }

}
