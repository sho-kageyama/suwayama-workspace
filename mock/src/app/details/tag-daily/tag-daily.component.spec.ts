import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TagDailyComponent } from './tag-daily.component';

describe('TagDailyComponent', () => {
  let component: TagDailyComponent;
  let fixture: ComponentFixture<TagDailyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TagDailyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TagDailyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
