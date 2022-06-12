using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation.Rules
{
    public class NameRule : ITextRule
    {
        private static readonly int _maxNameLength = 64;

        public RuleResult Validate(string? name)
        {
            if (name == null)
                return new RuleResult(false, ValidationStatus.FailedNameRule, $"The provided name ({name}) was null.");
            else if (name == "")
                return new RuleResult(false, ValidationStatus.FailedNameRule, $"The provided name (${name}) was empty.");
            else if (string.IsNullOrWhiteSpace(name))
                return new RuleResult(false, ValidationStatus.FailedNameRule, $"The provided name ({name}) only consisted of white-space characters.");
            else if (name.Length >= _maxNameLength)
                return new RuleResult(false, ValidationStatus.FailedNameRule, $"The provided name ({name}) was too big (max {_maxNameLength} characters).");
            else
                return new RuleResult(true, ValidationStatus.Ok, $"Ok. Provided name = {name}.");
        }
    }
}
