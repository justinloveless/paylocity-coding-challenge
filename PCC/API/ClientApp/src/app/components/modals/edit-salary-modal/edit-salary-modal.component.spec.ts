import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditSalaryModalComponent } from './edit-salary-modal.component';

describe('EditSalaryModalComponent', () => {
  let component: EditSalaryModalComponent;
  let fixture: ComponentFixture<EditSalaryModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditSalaryModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditSalaryModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
