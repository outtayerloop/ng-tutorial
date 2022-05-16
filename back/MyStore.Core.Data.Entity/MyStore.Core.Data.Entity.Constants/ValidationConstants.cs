namespace MyStore.Core.Data.Entity.Constants
{
    public static class ValidationConstants
    {
        /// <summary>
        /// Message issued when validation ended up being labeled as successful.
        /// </summary>
        public static readonly string ValidityMessage = "Ok";

        /// <summary>
        /// Message issued when validation received a null input.
        /// </summary>
        public static readonly string NullInputMessage = "Input was null";

        /// <summary>
        /// Message issued when validation failed on at least one field.
        /// </summary>
        public static readonly string InvalidFieldsMessage = "One or more input fields were invalid";
    }
}
