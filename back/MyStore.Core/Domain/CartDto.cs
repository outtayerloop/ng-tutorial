using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain
{
    public class CartDto : BaseDto
    {
        public CartDto(uint id) : base(id)
            => Products = new List<ProductDto>();

        public List<ProductDto> Products { get; set; }
    }
}
