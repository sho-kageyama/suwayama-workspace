import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoneyFlowEditComponent } from './money-flow-edit.component';

describe('MoneyFlowEditComponent', () => {
  let component: MoneyFlowEditComponent;
  let fixture: ComponentFixture<MoneyFlowEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoneyFlowEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoneyFlowEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
