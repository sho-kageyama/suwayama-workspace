import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintHistoryDetailsComponent } from './print-history-details.component';

describe('PrintHistoryDetailsComponent', () => {
  let component: PrintHistoryDetailsComponent;
  let fixture: ComponentFixture<PrintHistoryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrintHistoryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintHistoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
