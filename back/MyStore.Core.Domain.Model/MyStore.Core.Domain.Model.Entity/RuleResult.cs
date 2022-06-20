namespace MyStore.Core.Domain.Model.Entity
{
    public class RuleResult
    {
        public bool IsValid { get; }

        public ValidationStatus Status { get; }

        public string Message { get; }

        public RuleResult(bool isValid, ValidationStatus status, string message)
        {
            IsValid = isValid;
            Status = status;
            Message = message;
        }
    }
}
