import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDetailsModalComponent } from './employee-details-modal.component';

describe('EmployeeDetailsModalComponent', () => {
  let component: EmployeeDetailsModalComponent;
  let fixture: ComponentFixture<EmployeeDetailsModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeDetailsModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDetailsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
