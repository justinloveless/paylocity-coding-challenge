import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveDependantComponent } from './remove-dependant.component';

describe('RemoveDependantComponent', () => {
  let component: RemoveDependantComponent;
  let fixture: ComponentFixture<RemoveDependantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemoveDependantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoveDependantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
