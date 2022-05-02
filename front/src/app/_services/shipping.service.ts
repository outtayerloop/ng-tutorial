import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipping } from '../_models/shipping';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ShippingService extends BaseService {

  getAllShippings(): Observable<Shipping[]>{
    return this.http.get<Shipping[]>(`${this.apiUrl}/shippings`);
  }
}
