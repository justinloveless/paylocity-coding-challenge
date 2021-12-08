import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Employee} from "../../models/employee";
import {MatDialog} from "@angular/material/dialog";
import {AddEmployeeModalComponent} from "../modals/add-employee-modal/add-employee-modal.component";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  @Input() employees: Employee[] = [];
  @Output() reloadRequested = new EventEmitter<void>();

  constructor(private dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  addEmployee(){
    const dialogRef = this.dialog.open(AddEmployeeModalComponent, {
      data: {
      //  placeholder for any data I want to send to the component
      }
    })
    dialogRef.afterClosed().subscribe(result => {
    //  what should happen after the dialog has closed?
      if (result && result.success) {
        // we need to reload the employees and recalculate the summary
        this.reloadRequested.emit();
        this.snackBar.open("Employee added", "Dismiss", {duration: 2000})
      }
    })
  }
}
