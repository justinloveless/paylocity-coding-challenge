import {Component, Input, OnInit} from '@angular/core';
import {Employee} from "../../models/employee";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  @Input() employees: Employee[] = [];

  constructor() { }

  ngOnInit(): void {
  }

  addEmployee(){
    alert("Not implemented yet")
  }
}
