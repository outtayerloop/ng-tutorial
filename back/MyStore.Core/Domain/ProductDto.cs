using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain
{
    public class ProductDto : BaseDto
    {
        public ProductDto(uint id, string name, decimal price, string description) : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public string Name { get; }

        public decimal Price { get; }

        public string Description { get; }
    }
}