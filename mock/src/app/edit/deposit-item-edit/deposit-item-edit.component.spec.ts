import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepositItemEditComponent } from './deposit-item-edit.component';

describe('DepositItemEditComponent', () => {
  let component: DepositItemEditComponent;
  let fixture: ComponentFixture<DepositItemEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepositItemEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepositItemEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
