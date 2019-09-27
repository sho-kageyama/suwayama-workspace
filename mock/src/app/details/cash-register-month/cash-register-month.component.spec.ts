import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CashRegisterMonthComponent } from './cash-register-month.component';

describe('CashRegisterMonthComponent', () => {
  let component: CashRegisterMonthComponent;
  let fixture: ComponentFixture<CashRegisterMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CashRegisterMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CashRegisterMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
