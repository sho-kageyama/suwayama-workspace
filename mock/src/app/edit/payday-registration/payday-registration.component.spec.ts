import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaydayRegistrationComponent } from './payday-registration.component';

describe('PaydayRegistrationComponent', () => {
  let component: PaydayRegistrationComponent;
  let fixture: ComponentFixture<PaydayRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaydayRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaydayRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
