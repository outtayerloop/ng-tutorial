using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    internal interface INumberRule
    {
        RuleResult Validate(double? input);
    }
}
