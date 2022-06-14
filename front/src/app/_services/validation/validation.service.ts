import { Injectable } from '@angular/core';
import { RuleResult } from 'src/app/_models/rule-result';
import { Product } from '../../_models/product';
import { ValidationResult } from '../../_models/validation-result';
import { ValidationStatus } from '../../_models/validation-status';
import { DescriptionRule } from './description-rule.service';
import { NameRule } from './name-rule.service';
import { PriceRule } from './price-rule.service';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor(
    private readonly nameRule : NameRule, 
    private readonly descriptionRule : DescriptionRule, 
    private readonly priceRule : PriceRule){}

  /**
   * Determines whether the provided products are valid.
   * @param products Provided products.
   * @returns true if the products were all valid, else returns false.
   */
  public validateProductRange(products : (Product | null)[] | null) : ValidationResult[]
  {
    if (products === null)
      return this.getNullProductRangeResult();
    else
    {
      const validationResults : ValidationResult[] = [];
      let productValidation : ValidationResult;
      products.forEach(product =>
      {
          productValidation = this.validateSingle(product);
          validationResults.push(productValidation);
      });
      return validationResults;
    }
  }

  private getNullProductRangeResult() : ValidationResult[]
  {
    const validationResults : ValidationResult[] = [];
    const productValidation = new ValidationResult();
    productValidation.ruleResults.push(new RuleResult(false, ValidationStatus.Null, "The provided product range was null."));
    validationResults.push(productValidation);
    return validationResults;
  }

  private validateSingle(product : Product | null) : ValidationResult
  {
    const productValidation = new ValidationResult();
    if (product === null)
        productValidation.ruleResults.push(new RuleResult(false, ValidationStatus.Null, "The provided product was null."));
    else
    productValidation.ruleResults = productValidation.ruleResults.concat(this.getRuleResults(product));
    return productValidation;
  }

  private getRuleResults(product : Product) : RuleResult[]
  {
    const results : RuleResult[] = [];
    results.push(this.nameRule.validate(product.name));
    results.push(this.descriptionRule.validate(product.description));
    results.push(this.priceRule.validate(product.price));
    return results;
  }
}
