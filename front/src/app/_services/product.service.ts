import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Product } from '../_models/product';
import { BaseService as BaseHttpService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseHttpService {
  private readonly createdProductsSubject = new BehaviorSubject<Product[]>([]);
  readonly createdProducts = this.createdProductsSubject.asObservable();

  getAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.apiUrl}/products`);
  }

  addProductRange(products: Product[]): Observable<Product[]> {
    return this.http.post<Product[]>(`${this.apiUrl}/products`, products);
  }
}
