namespace MyStore.Core.Data.Entity.Constants
{
    public static class ProductConstants
    {
        /// <summary>
        /// Minimum valid price for a product.
        /// </summary>
        public static readonly decimal MinPrice = 0.01M;

        /// <summary>
        /// Maximum valid price for a product.
        /// </summary>
        public static readonly decimal MaxPrice = 100_000M;

        /// <summary>
        /// Maximum valid name length for a product.
        /// </summary>
        public static readonly int MaxNameLenth = 64;

        /// <summary>
        /// Maximum valid description length for a product.
        /// </summary>
        public static readonly int MaxDescriptionLenth = 128;
    }
}