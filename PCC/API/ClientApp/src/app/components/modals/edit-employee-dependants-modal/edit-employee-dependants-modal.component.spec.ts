import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditEmployeeDependantsModalComponent } from './edit-employee-dependants-modal.component';

describe('EditEmployeeDependantsModalComponent', () => {
  let component: EditEmployeeDependantsModalComponent;
  let fixture: ComponentFixture<EditEmployeeDependantsModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditEmployeeDependantsModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditEmployeeDependantsModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
