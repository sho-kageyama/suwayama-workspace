import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StuffManagementComponent } from './stuff-management.component';

describe('StuffManagementComponent', () => {
  let component: StuffManagementComponent;
  let fixture: ComponentFixture<StuffManagementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StuffManagementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StuffManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
