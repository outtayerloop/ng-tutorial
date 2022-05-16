using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Validation
{
    public interface IValidator
    {
        /// <summary>
        /// Determines whether the provided <paramref name="range"/> is valid
        /// in a context of creation (e.g : new lines inserted into the database).
        /// </summary>
        /// <typeparam name="TDto">Type of the DTO to use for creation</typeparam>
        /// <param name="range">List of DTOs to use for creation</param>
        /// <returns></returns>
        ValidationModel ValidateCreationRange<TDto>(List<TDto> range) where TDto : BaseDto;
    }
}
