import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MemoSummaryComponent } from './memo-summary.component';

describe('MemoSummaryComponent', () => {
  let component: MemoSummaryComponent;
  let fixture: ComponentFixture<MemoSummaryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MemoSummaryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MemoSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
