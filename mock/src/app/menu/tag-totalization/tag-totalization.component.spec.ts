import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TagTotalizationComponent } from './tag-totalization.component';

describe('TagTotalizationComponent', () => {
  let component: TagTotalizationComponent;
  let fixture: ComponentFixture<TagTotalizationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TagTotalizationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TagTotalizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
