import { RuleResult } from "../../_models/rule-result";

export interface ITextRule {
    validate(input : string | null) : RuleResult;
}
