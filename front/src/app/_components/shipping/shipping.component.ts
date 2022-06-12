import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Shipping } from 'src/app/_models/shipping';

import { ShippingService } from '../../_services/shipping.service';

@Component({
  selector: 'app-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.css'],
})
export class ShippingComponent implements OnInit, OnDestroy {
  shippingCosts!: Shipping[];
  private retrievedShippingsSubscription !: Subscription;

  constructor(private shippingService: ShippingService) {}

  ngOnInit(): void {
    this.retrievedShippingsSubscription = this.shippingService.getAllShippings().subscribe(res => this.shippingCosts = res);
  }

  ngOnDestroy(): void {
      this.retrievedShippingsSubscription.unsubscribe();
  }
}
