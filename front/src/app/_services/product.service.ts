import { HttpErrorResponse, HttpRequest } from '@angular/common/http';
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

  addProductRange(products: Product[]): void {
    if(products.length > 0){
      console.log(products);
      this.http.post(`${this.apiUrl}/products`, products).subscribe({
        next: res => this.createdProductsSubject.next(<Product[]>res),
        error: (err: HttpErrorResponse) => {
          const errorMessage = err.error.status && err.error.message
            ? `Status : ${err.error.status}. Message : ${err.error.message}`
            : err.error.title;
          alert(errorMessage);
        }
      })
    }
  }
}
