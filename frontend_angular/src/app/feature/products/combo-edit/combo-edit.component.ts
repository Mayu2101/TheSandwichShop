import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs';
import { Combo } from '../models/combo.model';

@Component({
  selector: 'app-combo-edit',
  templateUrl: './combo-edit.component.html',
  styleUrls: ['./combo-edit.component.scss'],
})
export class ComboEditComponent {
  public comboEditForm: FormGroup;
  public comboId: string;
  public isLoading = true;
  public mode: string;

  constructor(
    private productsService: ProductsService,
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
  ) {
    this.comboEditForm = new FormGroup({});
    this.mode = 'add';
    this.comboId = '';
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((param) => {
      const id = param['id'];
      this.mode = id === '0' ? 'add' : 'edit';
      if (this.mode === 'edit') {
        this.productsService
          .getCombo(id)
          .pipe(take(1))
          .subscribe((data: Combo) => {
            this.setFormValues(data);
            this.comboId = data.comboId;
            this.isLoading = false; 
          });
      } else {
        this.setFormValues({
          comboId: 'Auto Generated',
          description: '',
        });
        this.isLoading = false;
      }
    });
  }

  saveCombo() {
    if (this.mode === 'add') {
      this.productsService.createCombo(this.comboEditForm.value)
        .pipe(take(1))
        .subscribe(data => {
          this.router.navigate(['../products/combo', data.comboId]);
        });
    } else {
      this.productsService.updateCombo(this.comboEditForm.value)
        .pipe(take(1))
        .subscribe(data => {
        });
    }
  }

  private setFormValues(combo: Combo) {
    this.comboEditForm = this.fb.group({
      comboId: [combo.comboId],
      description: [combo.description, [Validators.required]],
    });
  }
}
