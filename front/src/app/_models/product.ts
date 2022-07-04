import { BaseModel } from "./base";

export class Product extends BaseModel {
  name: string;
  price: number;
  description: string;
  shippingDate: Date;
  shipped: boolean;

  constructor(jsonData: any){
    super(jsonData);
    this.name = jsonData.name;
    this.price = jsonData.price;
    this.description = jsonData.description;
    this.shippingDate = jsonData.shippingDate;
    this.shipped = jsonData.shipped === `true`;
  }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/