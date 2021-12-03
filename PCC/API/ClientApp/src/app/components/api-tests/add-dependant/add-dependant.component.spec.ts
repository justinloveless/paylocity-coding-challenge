import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDependantComponent } from './add-dependant.component';

describe('AddDependantComponent', () => {
  let component: AddDependantComponent;
  let fixture: ComponentFixture<AddDependantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDependantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDependantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
