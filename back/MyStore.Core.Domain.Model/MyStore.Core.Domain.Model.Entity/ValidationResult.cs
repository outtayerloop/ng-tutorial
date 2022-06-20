namespace MyStore.Core.Domain.Model.Entity
{
    public class ValidationResult
    {
        public bool IsValid => HasValidRuleResults();

        public List<RuleResult> RuleResults { get; }

        public ValidationResult()
            => RuleResults = new List<RuleResult>();

        private bool HasValidRuleResults()
        {
            return RuleResults.Count == 0
                || RuleResults.All(r => r.IsValid);
        }
    }
}
