import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ValidationResult } from 'src/app/_models/validation-result';

import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit, OnDestroy {
  products !: Product[];
  private retrievedProductsSubscription !: Subscription;
  validationResults !: ValidationResult[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.retrievedProductsSubscription = this.productService.getAllProducts().subscribe(res => this.products = res);
  }

  ngOnDestroy(): void {
    this.retrievedProductsSubscription.unsubscribe();
  }

  share() {
    window.alert('The product has been shared!');
  }

  onNotify = () => {
    window.alert('You will be notified when the product goes on sale');
  }

  onCreatedProducts(products: Product[]): void {
    this.products = this.products.concat(products);
  }

  onValidationErrors(validationResults: ValidationResult[]): void {
    this.validationResults = validationResults.filter(r => !r.isValid());
  }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
