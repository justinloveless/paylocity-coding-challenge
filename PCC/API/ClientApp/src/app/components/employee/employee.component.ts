import {Component, Input, OnInit} from '@angular/core';
import {Employee} from "../../models/employee";

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
  @Input() employee!: Employee;

  constructor() { }

  ngOnInit(): void {
  }

  openDependantsDialog(){
    alert("Not implemented yet")
  }

  editSalaryDialog(){
    alert("Not implemented yet")
  }

}
