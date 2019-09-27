import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KyastManagementDetailsComponent } from './kyast-management-details.component';

describe('KyastManagementDetailsComponent', () => {
  let component: KyastManagementDetailsComponent;
  let fixture: ComponentFixture<KyastManagementDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KyastManagementDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KyastManagementDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
