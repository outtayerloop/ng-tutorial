import { Component, OnInit } from '@angular/core';
import { Shipping } from 'src/app/_models/shipping';

import { ShippingService } from '../../_services/shipping.service';

@Component({
  selector: 'app-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.css'],
})
export class ShippingComponent implements OnInit {
  shippingCosts!: Shipping[];
  constructor(private shippingService: ShippingService) {}

  ngOnInit(): void {
    this.shippingService.getAllShippings().subscribe(res => this.shippingCosts = res);
  }
}
