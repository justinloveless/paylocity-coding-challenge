import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApiTestsComponent } from './api-tests.component';

describe('ApiTestsComponent', () => {
  let component: ApiTestsComponent;
  let fixture: ComponentFixture<ApiTestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApiTestsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiTestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
