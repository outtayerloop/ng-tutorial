import { Injectable } from '@angular/core';
import { RuleResult } from '../../_models/rule-result';
import { ValidationStatus } from '../../_models/validation-status';
import { StringUtils } from '../../_utils/string-utils';
import { ITextRule } from './text-rule.service';

@Injectable({
  providedIn: 'root'
})
export class NameRule implements ITextRule {

  private static readonly maxNameLength : number = 64;

  public validate(name : string | null) : RuleResult
  {
      if (name == null)
          return new RuleResult(false, ValidationStatus.FailedNameRule, `The provided name (${name}) was null.`);
      else if (name == "")
          return new RuleResult(false, ValidationStatus.FailedNameRule, `The provided name (${name}) was empty.`);
      else if (StringUtils.isNullOrWhiteSpace(name))
          return new RuleResult(false, ValidationStatus.FailedNameRule, `The provided name (${name}) only consisted of white-space characters.`);
      else if (name.length >= NameRule.maxNameLength)
          return new RuleResult(false, ValidationStatus.FailedNameRule, `The provided name (${name}) was too big (max ${NameRule.maxNameLength} characters).`);
      else
          return new RuleResult(true, ValidationStatus.Ok, `Ok. Provided name = ${name}.`);
  }
}
