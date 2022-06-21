import { Injectable } from '@angular/core';
import { RuleResult } from '../../_models/rule-result';
import { ValidationStatus } from '../../_models/validation-status';
import { INumberRule } from './number-rule.service';

@Injectable({
  providedIn: 'root'
})
export class PriceRule implements INumberRule {

  /**
   * Minimum valid price for a product.
   */
  private static readonly minPrice : number = 1;

  /**
   * Maximum valid price for a product.
   */
  private static readonly maxPrice : number = 100_000;
  
  validate(price: number | null): RuleResult {
    if (price === null)
        return new RuleResult(false, ValidationStatus.Null, "The provided price was null.");
    else if (price < PriceRule.minPrice)
        return new RuleResult(false, ValidationStatus.FailedPriceRule, `The provided price value (${price}) cannot be under ${PriceRule.minPrice}.`);
    else if (price > PriceRule.maxPrice)
        return new RuleResult(false, ValidationStatus.FailedPriceRule, `The provided price value (${price}) cannot be above ${PriceRule.maxPrice}.`);
    else
        return new RuleResult(true, ValidationStatus.Ok, `Ok. Provided price = ${price}`);
  }
}
