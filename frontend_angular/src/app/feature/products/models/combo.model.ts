export interface Combo {
  comboId: string;
  description: string;
}

export interface ComboItem {
  id: string;
  itemId: string;
  comboId: string;
}

export interface ComboBasePrice {
  comboId: string;
  price: number;
}
