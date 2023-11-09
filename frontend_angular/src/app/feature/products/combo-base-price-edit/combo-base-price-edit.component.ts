import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { ProductsService } from '../products.service';
import { ComboBasePrice } from '../models/combo.model';

@Component({
  selector: 'app-combo-base-price-edit',
  templateUrl: './combo-base-price-edit.component.html',
  styleUrls: ['./combo-base-price-edit.component.scss']
})
export class ComboBasePriceEditComponent {

  @Input() public comboId = '';
  public comboBasePriceEditForm: FormGroup;
  public isLoading = true;

  constructor(
    private productsService: ProductsService,
    private fb: FormBuilder,
  ) {
    this.comboBasePriceEditForm = new FormGroup({});
  }

  ngOnInit(): void {
    this.productsService
      .getComboBasePrice(this.comboId)
      .pipe(take(1))
      .subscribe((data: ComboBasePrice) => {
        if (data == null) {
          this.setFormValues({ comboId: this.comboId, price: 0 });
        } else {
          this.setFormValues(data);
        }
        this.isLoading = false;
      });
  }

  saveComboBasePrice() {
    this.productsService.updateComboBasePrice(this.comboBasePriceEditForm.value)
      .pipe(take(1))
      .subscribe((data: ComboBasePrice) => {
        console.log('Combo updated successfully');
      });
  }

  private setFormValues(comboBasePrice: ComboBasePrice) {
    this.comboBasePriceEditForm = this.fb.group({
      comboId: [comboBasePrice.comboId],
      price: [comboBasePrice.price, [Validators.required]],
    });
  }
}
