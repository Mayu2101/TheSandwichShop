import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComboBasePriceEditComponent } from './combo-base-price-edit.component';

describe('ComboBasePriceEditComponent', () => {
  let component: ComboBasePriceEditComponent;
  let fixture: ComponentFixture<ComboBasePriceEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ComboBasePriceEditComponent]
    });
    fixture = TestBed.createComponent(ComboBasePriceEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
