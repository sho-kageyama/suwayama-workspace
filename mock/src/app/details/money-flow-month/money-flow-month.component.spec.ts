import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoneyFlowMonthComponent } from './money-flow-month.component';

describe('MoneyFlowMonthComponent', () => {
  let component: MoneyFlowMonthComponent;
  let fixture: ComponentFixture<MoneyFlowMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoneyFlowMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoneyFlowMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
