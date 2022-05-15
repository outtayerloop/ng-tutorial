import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Product } from '../_models/product';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService {
  private createdProductsSubject = new BehaviorSubject<Product[]>([]);
  createdProducts = this.createdProductsSubject.asObservable();

  getAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.apiUrl}/products`);
  }

  addProductRange(products: Product[]): void {
    if(products.length > 0){
      this.http.post(`${this.apiUrl}/products`, products).subscribe({
        next: res => this.createdProductsSubject.next(<Product[]>res),
        error: (err: HttpErrorResponse) => alert(err.error)
      })
    }
    else
      alert("An empty product list was uploaded");
  }
}
