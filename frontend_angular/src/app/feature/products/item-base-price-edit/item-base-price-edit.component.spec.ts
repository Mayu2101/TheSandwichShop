import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemBasePriceEditComponent } from './item-base-price-edit.component';

describe('ItemBasePriceEditComponent', () => {
  let component: ItemBasePriceEditComponent;
  let fixture: ComponentFixture<ItemBasePriceEditComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ItemBasePriceEditComponent]
    });
    fixture = TestBed.createComponent(ItemBasePriceEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
