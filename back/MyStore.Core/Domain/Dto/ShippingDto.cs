using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain.Dto
{
    public class ShippingDto : BaseDto
    {
        public ShippingDto(uint id, ShippingPackage package, decimal price) : base(id)
        {
            Package = package;
            Price = price;
        }

        public ShippingPackage Package { get; }

        public decimal Price { get; }
    }
}
