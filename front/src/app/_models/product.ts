import { BaseModel } from "./base";

export interface Product extends BaseModel {
  name: string;
  price: number;
  description: string;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/