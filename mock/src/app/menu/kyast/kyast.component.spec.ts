import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KyastComponent } from './kyast.component';

describe('KyastComponent', () => {
  let component: KyastComponent;
  let fixture: ComponentFixture<KyastComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KyastComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KyastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
