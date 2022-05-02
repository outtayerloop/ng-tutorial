import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Product } from '../_models/product';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService {

  getAllProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.apiUrl}/products`);
  }
}
