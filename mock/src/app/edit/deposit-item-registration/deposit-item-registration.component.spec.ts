import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DepositItemRegistrationComponent } from './deposit-item-registration.component';

describe('DepositItemRegistrationComponent', () => {
  let component: DepositItemRegistrationComponent;
  let fixture: ComponentFixture<DepositItemRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepositItemRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepositItemRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
