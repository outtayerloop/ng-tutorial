import { ValidationStatus } from "./validation-status";

export class RuleResult{

    constructor(
        public readonly isValid : boolean, 
        public readonly status : ValidationStatus,
        public readonly message : string){}
}