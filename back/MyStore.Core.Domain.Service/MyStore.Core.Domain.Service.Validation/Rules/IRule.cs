using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    public interface IRule
    {
        RuleResult Validate(ProductModel product);
    }
}
