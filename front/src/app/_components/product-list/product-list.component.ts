import { Component, OnInit } from '@angular/core';

import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent implements OnInit {
  products!: Product[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(res => this.products = res);
  }

  share() {
    window.alert('The product has been shared!');
  }

  onNotify = () => {
    window.alert('You will be notified when the product goes on sale');
  };

  onCreatedProducts(products: Product[]): void {
    this.products = this.products.concat(products);
  }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
