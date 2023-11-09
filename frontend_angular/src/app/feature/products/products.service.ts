import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Item, ItemBasePrice } from './models/item.model';
import { Topping } from './models/topping.model';
import { Bread } from './models/bread.model';
import { Size } from './models/size.model';
import { Combo, ComboBasePrice } from './models/combo.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  apiUrl = environment.apiUrl + '/Product';

  httpOptions = {
    headers: new HttpHeaders({
      ContentType: 'application/json',
    }),
  };

  constructor(private httpClient: HttpClient) {}

  // Items Services
  getAllItems(): Observable<Item[]> {
    return this.httpClient.get<Item[]>(`${this.apiUrl}/GetItems`, this.httpOptions)
  }

  getItem(id: string) {
    let params = new HttpParams().set('itemId', id);
    return this.httpClient.get<Item>(`${this.apiUrl}/GetItem`, {params: params, ...this.httpOptions})
  }

  createItem(item: Item) {
    item.itemId = '';
    return this.httpClient.post<Item>(`${this.apiUrl}/AddItem`, item, this.httpOptions)
  }

  updateItem(item: Item) {
    return this.httpClient.post<Item>(`${this.apiUrl}/UpdateItem`, item, this.httpOptions)
  }

  getItemBasePrice(itemId: string) {
    let params = new HttpParams().set('itemId', itemId);
    return this.httpClient.get<ItemBasePrice>(`${this.apiUrl}/GetItemBasePrice`, {params: params, ...this.httpOptions})
  }
  
  updateItemBasePrice(itemBasePrice: ItemBasePrice) {
    return this.httpClient.post<ItemBasePrice>(`${this.apiUrl}/AddItemBasePrice`, itemBasePrice, this.httpOptions)
  }

  // Bread Services
  getAllBreads(): Observable<Bread[]> {
    return this.httpClient.get<Bread[]>(`${this.apiUrl}/GetBreadTypes`, this.httpOptions)
  }

  getBread(id: string) {
    let params = new HttpParams().set('breadTypeId', id);
    return this.httpClient.get<Bread>(`${this.apiUrl}/GetBreadType`, {params: params, ...this.httpOptions})
  }

  createBread(bread: Bread) {
    bread.breadTypeId = '';
    return this.httpClient.post<Bread>(`${this.apiUrl}/AddBreadType`, bread, this.httpOptions)
  }

  updateBread(bread: Bread) {
    return this.httpClient.post<Bread>(`${this.apiUrl}/UpdateBreadType`, bread, this.httpOptions)
  }

  // Toppings Services
  getAllToppings(): Observable<Topping[]> {
    return this.httpClient.get<Topping[]>(`${this.apiUrl}/GetToppings`, this.httpOptions)
  }

  getTopping(id: string) {
    let params = new HttpParams().set('toppingId', id);
    return this.httpClient.get<Topping>(`${this.apiUrl}/GetTopping`, {params: params, ...this.httpOptions})
  }

  createTopping(topping: Topping) {
    topping.toppingId = '';
    return this.httpClient.post<Topping>(`${this.apiUrl}/AddTopping`, topping, this.httpOptions)
  }

  updateTopping(topping: Topping) {
    return this.httpClient.post<Topping>(`${this.apiUrl}/UpdateTopping`, topping, this.httpOptions)
  }

  // Sizes Services
  getAllSizes(): Observable<Size[]> {
    return this.httpClient.get<Size[]>(`${this.apiUrl}/GetSizes`, this.httpOptions)
  }

  getSize(id: string) {
    let params = new HttpParams().set('sizeId', id);
    return this.httpClient.get<Size>(`${this.apiUrl}/GetSize`, {params: params, ...this.httpOptions})
  }

  createSize(size: Size) {
    size.sizeId= '';
    return this.httpClient.post<Size>(`${this.apiUrl}/AddSize`, size, this.httpOptions)
  }

  updateSize(size: Size) {
    console.log(size)
    return this.httpClient.post<Size>(`${this.apiUrl}/UpdateSize`, size, this.httpOptions)
  }

  // Combos Services
  getAllCombos(): Observable<Combo[]> {
    return this.httpClient.get<Combo[]>(`${this.apiUrl}/GetCombos`, this.httpOptions)
  }

  getCombo(id: string) {
    let params = new HttpParams().set('comboId', id);
    return this.httpClient.get<Combo>(`${this.apiUrl}/GetCombo`, {params: params, ...this.httpOptions})
  }

  createCombo(combo: Combo) {
    combo.comboId= '';
    return this.httpClient.post<Combo>(`${this.apiUrl}/AddCombo`, combo, this.httpOptions)
  }

  updateCombo(combo: Combo) {
    return this.httpClient.post<Combo>(`${this.apiUrl}/UpdateCombo`, combo, this.httpOptions)
  }

  getComboBasePrice(comboId: string) {
    let params = new HttpParams().set('comboId', comboId);
    return this.httpClient.get<ComboBasePrice>(`${this.apiUrl}/GetComboBasePrice`, {params: params, ...this.httpOptions})
  }
  
  updateComboBasePrice(itemBasePrice: ComboBasePrice) {
    return this.httpClient.post<ComboBasePrice>(`${this.apiUrl}/AddComboBasePrice`, itemBasePrice, this.httpOptions)
  }
}
