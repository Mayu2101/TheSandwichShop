import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { Item } from '../models/item.model';

@Component({
  selector: 'app-item-edit',
  templateUrl: './item-edit.component.html',
  styleUrls: ['./item-edit.component.scss'],
})
export class ItemEditComponent {
  public itemEditForm: FormGroup;
  public categories: string[];
  public itemId: string;
  public isLoading = true;
  public mode: string;

  constructor(
    private productsService: ProductsService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {
    this.itemEditForm = new FormGroup({});
    this.mode = 'add';
    this.itemId = '';
    this.categories = ['Drink', 'Sandwich', 'Dessert'];
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param) => {
      const id = param['id'];
      this.mode = id === '0' ? 'add' : 'edit';
      if (this.mode === 'edit') {
        this.productsService
          .getItem(id)
          .pipe(take(1))
          .subscribe((data: Item) => {
            this.setFormValues(data);
            this.itemId = data.itemId;
            this.isLoading = false;
          });
      } else {
        this.setFormValues({
          itemId: 'Auto Generated',
          description: '',
          category: '',
        });
        this.isLoading = false;
      }
    });
  }

  saveItem() {
    if (this.mode === 'add') {
      this.productsService.createItem(this.itemEditForm.value)
        .pipe(take(1))
        .subscribe((data: Item) => {
          this.router.navigate(['../products/item', data.itemId]); 
        });
    } else {
      this.productsService.updateItem(this.itemEditForm.value)
        .pipe(take(1))
        .subscribe((data: Item) => {
        });
    }
  }

  private setFormValues(item: Item) {
    this.itemEditForm = this.fb.group({
      itemId: [item.itemId],
      description: [item.description, [Validators.required]],
      category: [item.category, [Validators.required]],
    });
  }
}
