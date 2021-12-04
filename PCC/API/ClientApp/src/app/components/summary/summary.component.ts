import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.scss']
})
export class SummaryComponent implements OnInit {
  @Input() deductionTotal: number = 0;
  @Input() employeeCount: number = 0;
  @Input() dependantCount: number = 0;
  @Input() isReady: boolean = false;


  constructor() { }

  ngOnInit(): void {
  }

}
