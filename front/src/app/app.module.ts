import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { TopBarComponent } from './_components/top-bar/top-bar.component';
import { ProductListComponent } from './_components/product-list/product-list.component';
import { ProductAlertsComponent } from './_components/product-alerts/product-alerts.component';
import { ProductDetailsComponent } from './_components/product-details/product-details.component';
import { CartComponent } from './_components/cart/cart.component';
import { ShippingComponent } from './_components/shipping/shipping.component';
import { ProductUploadComponent } from './_components/product-upload/product-upload.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: '',
        component: ProductListComponent,
      },
      {
        path: 'products/:productId',
        component: ProductDetailsComponent,
      },
      {
        path: 'cart',
        component: CartComponent,
      },
      {
        path: 'shipping',
        component: ShippingComponent,
      },
    ]),
  ],
  declarations: [
    AppComponent,
    TopBarComponent,
    ProductListComponent,
    ProductAlertsComponent,
    ProductDetailsComponent,
    CartComponent,
    ShippingComponent,
    ProductUploadComponent,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
