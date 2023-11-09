import { Component, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../products.service';
import { take } from 'rxjs';
import { Item, ItemBasePrice } from '../models/item.model';

@Component({
  selector: 'app-item-base-price-edit',
  templateUrl: './item-base-price-edit.component.html',
  styleUrls: ['./item-base-price-edit.component.scss']
})
export class ItemBasePriceEditComponent {

  @Input() public itemId = '';
  public itemBasePriceEditForm: FormGroup;
  public isLoading = true;

  constructor(
    private productsService: ProductsService,
    private fb: FormBuilder,
  ) {
    this.itemBasePriceEditForm = new FormGroup({});
  }

  ngOnInit(): void {
    this.productsService
      .getItemBasePrice(this.itemId)
      .pipe(take(1))
      .subscribe((data: ItemBasePrice) => {
        if (data == null) {
          this.setFormValues({ itemId: this.itemId, price: 0 });
        } else {
          this.setFormValues(data);
        }
        this.isLoading = false;
      });
  }

  saveItemBasePrice() {
    this.productsService.updateItemBasePrice(this.itemBasePriceEditForm.value)
      .pipe(take(1))
      .subscribe((data: ItemBasePrice) => {
        console.log('Item updated successfully');
      });
  }

  private setFormValues(itemBasePrice: ItemBasePrice) {
    this.itemBasePriceEditForm = this.fb.group({
      itemId: [itemBasePrice.itemId],
      price: [itemBasePrice.price, [Validators.required]],
    });
  }
}
