using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    public class DescriptionRule : IRule
    {
        public static readonly int _maxDescriptionLength = 128;

        public RuleResult Validate(ProductModel product)
            => ValidateDescription(product.Description);

        private RuleResult ValidateDescription(string? description)
        {
            if (string.IsNullOrEmpty(description))
                return new RuleResult(true, ValidationStatus.Ok, $"Ok. Provided description was null or empty.");
            if (description != null && description.Trim() == "")
                return new RuleResult(false, ValidationStatus.FailedDescriptionRule, $"The provided description ({description}) only consisted of white-space characters.");
            else if (description!.Length >= _maxDescriptionLength)
                return new RuleResult(false, ValidationStatus.FailedDescriptionRule, $"The provided description ({description}) was too big (max {_maxDescriptionLength} characters).");
            else
                return new RuleResult(true, ValidationStatus.Ok, $"Ok. Provided description = {description}.");
        }
    }
}
