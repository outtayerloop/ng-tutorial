using MyStore.Core.Data.Entity.Constants;

namespace MyStore.Core.Domain.Model.Entity
{
    public class ValidationModel
    {
        public ValidationStatus Status { get; }

        public string Message 
        { 
            get
            {
                return Status switch
                {
                    ValidationStatus.Valid => ValidationConstants.ValidityMessage,
                    ValidationStatus.NullInput => ValidationConstants.NullInputMessage,
                    ValidationStatus.InvalidFields => ValidationConstants.InvalidFieldsMessage,
                    _ => throw new NotImplementedException("No associated message found for given validity status")
                };
            }
        }

        public ValidationModel(ValidationStatus status)
            => Status = status;
    }
}
