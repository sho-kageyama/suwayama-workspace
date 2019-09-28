import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteHistoryDetailsComponent } from './delete-history-details.component';

describe('DeleteHistoryDetailsComponent', () => {
  let component: DeleteHistoryDetailsComponent;
  let fixture: ComponentFixture<DeleteHistoryDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteHistoryDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteHistoryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
