import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryItemRegistrationComponent } from './salary-item-registration.component';

describe('SalaryItemRegistrationComponent', () => {
  let component: SalaryItemRegistrationComponent;
  let fixture: ComponentFixture<SalaryItemRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaryItemRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaryItemRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
