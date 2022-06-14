import { RuleResult } from "./rule-result";

export class ValidationResult {
    public readonly ruleResults : RuleResult[] = [];

    public isValid() : boolean {
        return this.ruleResults.length == 0
            || this.ruleResults.every(r => r.isValid);
    }
}