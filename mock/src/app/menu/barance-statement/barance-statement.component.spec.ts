import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BaranceStatementComponent } from './barance-statement.component';

describe('BaranceStatementComponent', () => {
  let component: BaranceStatementComponent;
  let fixture: ComponentFixture<BaranceStatementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BaranceStatementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BaranceStatementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
