import { ValidationStatus } from "./validation-status";

export class Validation {
    private readonly VALIDITY_MESSAGE : string = "Ok";
    private readonly NULL_INPUT_MESSAGE : string = "Input was null";
    private readonly INVALID_FIELDS_MESSAGE : string = "One or more input fields were invalid";
    
    readonly status: ValidationStatus;
    readonly message: string;

    constructor(status: ValidationStatus){
        this.status = status;
        this.message = this.getMessage();
    }

    private getMessage(): string{
        switch(this.status){
            case ValidationStatus.Valid: {
                return this.VALIDITY_MESSAGE;
            }
            case ValidationStatus.NullInput: {
                return this.NULL_INPUT_MESSAGE;
            }
            case ValidationStatus.InvalidFields: {
                return this.INVALID_FIELDS_MESSAGE;
            }
            default: {
                throw new Error('No associated message found for given validity status');
            }
        }
    }
}