using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;

namespace MyStore.Core.Domain.Service.Validation
{
    public class ProductValidator : IProductValidator
    {
        private readonly IEnumerable<IRule> _rules;

        public ProductValidator(IEnumerable<IRule> rules)
            => _rules = rules;

        /// <summary>
        /// Determines whether the provided <paramref name="products"/> is valid.
        /// </summary>
        /// <param name="products">Provided products.</param>
        /// <returns></returns>
        public IReadOnlyCollection<ValidationResult> ValidateRange(List<ProductModel> products)
        {
            if (products == null)
                return GetNullProductRangeResult();
            else
            {
                var validationResults = new List<ValidationResult>();
                ValidationResult productValidation;
                products.ForEach(product =>
                {
                    productValidation = ValidateSingle(product);
                    validationResults.Add(productValidation);
                });
                return validationResults.AsReadOnly();
            }
        }

        private IReadOnlyCollection<ValidationResult> GetNullProductRangeResult()
        {
            var validationResults = new List<ValidationResult>();
            var productValidation = new ValidationResult();
            productValidation.RuleResults.Add(new RuleResult(false, ValidationStatus.Null, "The provided product range was null."));
            validationResults.Add(productValidation);
            return validationResults.AsReadOnly();
        }

        private ValidationResult ValidateSingle(ProductModel product)
        {
            var productValidation = new ValidationResult();
            if (product == null)
                productValidation.RuleResults.Add(new RuleResult(false, ValidationStatus.Null, "The provided product was null."));
            else
                productValidation.RuleResults.AddRange(GetRuleResults(product));
            return productValidation;
        }

        private List<RuleResult> GetRuleResults(ProductModel product)
        {
            var results = new List<RuleResult>();
            foreach(IRule rule in _rules)
                results.Add(rule.Validate(product));
            return results;
        }
    }
}