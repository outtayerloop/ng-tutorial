import { Injectable } from '@angular/core';

import { Product } from '../_models/product';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})
export class CartService extends BaseService {
  items: Product[] = [];

  addToCart(product: Product): void {
    this.items.push(product);
  }

  getItems(): Product[] {
    return this.items;
  }

  clearCart(): Product[] {
    this.items = [];
    return this.items;
  }
}
