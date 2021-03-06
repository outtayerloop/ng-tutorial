using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    public class PriceRule : IRule
    {
        /// <summary>
        /// Minimum valid price for a product.
        /// </summary>
        public static readonly decimal _minPrice = 1M;

        /// <summary>
        /// Maximum valid price for a product.
        /// </summary>
        public static readonly decimal _maxPrice = 100_000M;

        public RuleResult Validate(ProductModel product)
            => ValidatePrice(product.Price);

        private RuleResult ValidatePrice(decimal price)
        {
            if (price < _minPrice)
                return new RuleResult(false, ValidationStatus.FailedPriceRule, $"The provided price value ({price}) cannot be under {_minPrice}.");
            else if (price > _maxPrice)
                return new RuleResult(false, ValidationStatus.FailedPriceRule, $"The provided price value ({price}) cannot be above {_maxPrice}.");
            else
                return new RuleResult(true, ValidationStatus.Ok, $"Ok. Provided price = {price}");
        }
    }
}
