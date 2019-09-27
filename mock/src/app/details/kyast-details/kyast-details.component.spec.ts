import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KyastDetailsComponent } from './kyast-details.component';

describe('KyastDetailsComponent', () => {
  let component: KyastDetailsComponent;
  let fixture: ComponentFixture<KyastDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KyastDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KyastDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
