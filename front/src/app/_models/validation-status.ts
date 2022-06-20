export enum ValidationStatus {
    /**
     * The current input was null.
     */
    Null = 0,

    /**
     * The current input successfully passed validation.
     */
    Ok = 1,

    /**
     * The current input failed the name rule's validation.
     */
    FailedNameRule = 2,

    /**
     * The current input failed the description rule's validation.
     */
    FailedDescriptionRule = 3,

    /**
     * The current input failed the price rule's validation.
     */
    FailedPriceRule = 4
}