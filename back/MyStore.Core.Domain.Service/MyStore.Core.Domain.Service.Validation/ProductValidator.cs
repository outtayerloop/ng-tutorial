using AutoMapper;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Store;

namespace MyStore.Core.Domain.Service.Validation
{
    public class ProductValidator : IValidator
    {
        private readonly IMapper _mapper;

        public ProductValidator()
            => _mapper = Mapping.GetMapper();

        /// <summary>
        /// Determines whether the provided <paramref name="range"/> is valid
        /// in a context of creation (e.g : new lines inserted into the database).
        /// </summary>
        /// <typeparam name="TDto">Type of the DTO to use for creation</typeparam>
        /// <param name="range">List of DTOs to use for creation</param>
        /// <returns></returns>
        public ValidationModel ValidateCreationRange<TDto>(List<TDto> range) where TDto : BaseDto
        {
            ValidationStatus status;
            if (range == null)
                status = ValidationStatus.NullInput;
            else
            {
                range.RemoveAll(entity => entity == null);
                List<ProductModel> products = range.Select(p => _mapper.Map<ProductModel>(p)).ToList();
                bool allHaveValidNames = products.All(p => p.HasValidName());
                bool allHaveValidPrices = products.All(p => p.HasValidPrice());
                bool allHaveValidDescriptions = products.All(p => p.HasValidDescription());
                status = allHaveValidNames && allHaveValidPrices && allHaveValidDescriptions
                    ? ValidationStatus.Valid
                    : ValidationStatus.InvalidFields;
            }
            return new ValidationModel(status);
        }
    }
}