export interface Item {
  itemId: string;
  description: string;
  category: string;
  price?: number;
}

export interface ItemBasePrice {
  itemId: string;
  price: number;
}
