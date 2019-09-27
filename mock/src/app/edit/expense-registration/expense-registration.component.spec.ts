import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpenseRegistrationComponent } from './expense-registration.component';

describe('ExpenseRegistrationComponent', () => {
  let component: ExpenseRegistrationComponent;
  let fixture: ComponentFixture<ExpenseRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpenseRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpenseRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
