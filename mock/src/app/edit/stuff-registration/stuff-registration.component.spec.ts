import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StuffRegistrationComponent } from './stuff-registration.component';

describe('StuffRegistrationComponent', () => {
  let component: StuffRegistrationComponent;
  let fixture: ComponentFixture<StuffRegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StuffRegistrationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StuffRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
