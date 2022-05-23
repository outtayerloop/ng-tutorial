import { StringUtils } from "../_utils/string-utils";
import { BaseModel } from "./base";

export class Product extends BaseModel {
  private readonly MIN_PRICE: number = 0.01;
  private readonly MAX_PRICE: number = 100_000;
  private readonly MAX_NAME_LENGTH: number = 64;
  private readonly MAX_DESCRIPTION_LENGTH = 128;

  name: string;
  price: number;
  description: string;

  constructor(jsonData: any){
    super(jsonData);
    this.name = jsonData.name;
    this.price = jsonData.price;
    this.description = jsonData.description;
  }

  hasValidName(): boolean {
    return !StringUtils.isNullOrEmpty(this.name)
      && !StringUtils.isNullOrWhiteSpace(this.name)
      && this.name.length <= this.MAX_NAME_LENGTH;
  }

  hasValidPrice(): boolean {
    return this.price >= this.MIN_PRICE
      && this.price <= this.MAX_PRICE;
  }

  hasValidDescription(): boolean {
    return this.description == null
      || (
          !StringUtils.isNullOrWhiteSpace(this.description) 
          && this.description.length <= this.MAX_DESCRIPTION_LENGTH
      );
  }
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/