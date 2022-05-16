import { Injectable } from '@angular/core';
import { Product } from '../_models/product';
import { Validation } from '../_models/validation';
import { ValidationStatus } from '../_models/validation-status';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  validateProductRangeCreation(products: Product[]): Validation {
    let status: ValidationStatus;
    if (products === null)
      status = ValidationStatus.NullInput;
    else
    {
      products = products.filter(entity => entity !== null);
      const allHaveValidNames: boolean = products.every(product => product.hasValidName());
      const allHaveValidPrices: boolean = products.every(product => product.hasValidPrice());
      const allHaveValidDescriptions: boolean = products.every(product => product.hasValidDescription());
      status = allHaveValidNames && allHaveValidPrices && allHaveValidDescriptions
        ? ValidationStatus.Valid
        : ValidationStatus.InvalidFields;
    }
    return new Validation(status);
  }
}
