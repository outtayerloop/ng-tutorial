import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../../_models/product';

@Component({
  selector: 'app-product-alerts',
  templateUrl: './product-alerts.component.html',
  styleUrls: ['./product-alerts.component.css'],
})
export class ProductAlertsComponent implements OnInit {
  @Input() product!: Product | undefined;
  @Output() readonly notifyCustomEvent = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}
}
