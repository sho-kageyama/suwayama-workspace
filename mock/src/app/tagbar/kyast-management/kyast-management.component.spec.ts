import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KyastManagementComponent } from './kyast-management.component';

describe('KyastManagementComponent', () => {
  let component: KyastManagementComponent;
  let fixture: ComponentFixture<KyastManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KyastManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KyastManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
