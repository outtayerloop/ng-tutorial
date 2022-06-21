namespace MyStore.Core.Domain.Model.Entity
{
    /// <summary>
    /// Status issued for each input after validation.
    /// </summary>
    public enum ValidationStatus
    {
        /// <summary>
        /// The current input was null.
        /// </summary>
        Null = 0,

        /// <summary>
        /// The current input successfully passed validation.
        /// </summary>
        Ok = 1,

        /// <summary>
        /// The current input failed the name rule's validation.
        /// </summary>
        FailedNameRule = 2,

        /// <summary>
        /// The current input failed the description rule's validation.
        /// </summary>
        FailedDescriptionRule = 3,

        /// <summary>
        /// The current input failed the price rule's validation.
        /// </summary>
        FailedPriceRule = 4,

        /// <summary>
        /// The current input failed the date rule's validation.
        /// </summary>
        FailedDateRule = 4
    }
}
