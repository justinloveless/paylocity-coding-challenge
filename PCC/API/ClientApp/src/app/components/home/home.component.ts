import {Component, OnInit} from '@angular/core';
import {EmployeeService} from "../../services/employee.service";
import {CalculateDeductionsService} from "../../services/calculate-deductions.service";
import {MatSnackBar} from "@angular/material/snack-bar";
import {Employee} from "../../models/employee";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  employees: Employee[] = [];
  loadingEmployees = true;
  deductionTotal: number = 0;
  totalEmployees = 0;
  totalDependants = 0;
  loadingSummary = true;
  summaryInfoReady: boolean = false;





  constructor(private employeeService: EmployeeService,
              private calculateService: CalculateDeductionsService,
              private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.loadEmployees();
    this.loadSummary();
  }

  loadEmployees(){
    this.loadingEmployees = true;
    this.employeeService.getAll().subscribe(employees => {
      this.employees = employees;
      this.totalEmployees = this.employees.length;
      this.totalDependants = this.employees
        .map(e => e.dependants.length)
        .reduce((partial_sum, item) => partial_sum + item, 0);
      this.loadingEmployees = false;
      if (!this.loadingSummary)
        this.summaryInfoReady = true;

    }, error => {
      this.loadingEmployees = false;
      this.snackBar.open("Failed to load employees", "Dismiss", {
        duration: 2000
      })
    })
  }

  loadSummary(){
    this.loadingSummary = true;
    this.calculateService.getTotalDeductions().subscribe(deductionTotal => {
      this.deductionTotal = deductionTotal
      this.loadingSummary = false;
      if (!this.loadingEmployees)
        this.summaryInfoReady = true; // done loading employees, so we're also done getting the summary info
    })
  }



}
