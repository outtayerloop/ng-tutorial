import { Injectable } from '@angular/core';
import { RuleResult } from '../../_models/rule-result';
import { ValidationStatus } from '../../_models/validation-status';
import { StringUtils } from '../../_utils/string-utils';
import { ITextRule } from './text-rule.service';

@Injectable({
  providedIn: 'root'
})
export class DescriptionRule implements ITextRule {

  private static readonly maxDescriptionLength : number = 128;

  public validate(description : string | null) : RuleResult
  {
    if (StringUtils.isNullOrEmpty(description))
        return new RuleResult(true, ValidationStatus.Ok, `Ok. Provided description was null or empty.`);
    if (description != null && description.trim() == "")
        return new RuleResult(false, ValidationStatus.FailedDescriptionRule, `The provided description (${description}) only consisted of white-space characters.`);
    else if (description!.length >= DescriptionRule.maxDescriptionLength)
        return new RuleResult(false, ValidationStatus.FailedDescriptionRule, `The provided description (${description}) was too big (max ${DescriptionRule.maxDescriptionLength} characters).`);
    else
        return new RuleResult(true, ValidationStatus.Ok, `Ok. Provided description = ${description}.`);
  }
}
