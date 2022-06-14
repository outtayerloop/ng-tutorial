import { RuleResult } from "../../_models/rule-result";

export interface INumberRule {
  validate(input : number | null) : RuleResult;
}
