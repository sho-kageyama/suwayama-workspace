import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdactTotalizationComponent } from './prodact-totalization.component';

describe('ProdactTotalizationComponent', () => {
  let component: ProdactTotalizationComponent;
  let fixture: ComponentFixture<ProdactTotalizationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdactTotalizationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdactTotalizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
