using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation
{
    public interface IValidator<TModel> where TModel : BaseModel
    {
        /// <summary>
        /// Determines whether the provided <paramref name="range"/> is valid
        /// in a context of creation (e.g : new lines inserted into the database).
        /// </summary>
        /// <typeparam name="TModel">Type of the model to use for creation</typeparam>
        /// <param name="range">List of DTOs to use for creation</param>
        /// <returns></returns>
        IReadOnlyCollection<ValidationResult> ValidateRange(List<TModel> range);
    }
}
