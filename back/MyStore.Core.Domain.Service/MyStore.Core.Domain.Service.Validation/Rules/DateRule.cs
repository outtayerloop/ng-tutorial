using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    public class DateRule : IRule
    {
        /// <summary>
        /// Maximum number of days after which a product can be shipped.
        /// </summary>
        public static readonly int _productShippingMaxDelay = 10;

        public RuleResult Validate(ProductModel product)
        {
            if (!product.Shipped)
            {
                if (product.ShippingDate.CompareTo(DateTime.Now) < 0)
                {
                    TimeSpan difference = DateTime.Now - product.ShippingDate;
                    int passedDays = difference.Days;
                    if (passedDays > _productShippingMaxDelay)
                        return new RuleResult(false, ValidationStatus.FailedDateRule, $"The provided product with shipping date \"{product.ShippingDate:dd/MM/yyyy HH:mm}\" should have been shipped at most {passedDays} days ago (max delay = {_productShippingMaxDelay} days).");
                }
            }
            return new RuleResult(true, ValidationStatus.Ok, $"Ok. Provided shipping date = {product.ShippingDate:dd/MM/yyyy HH:mm}.");
        }
    }
}
