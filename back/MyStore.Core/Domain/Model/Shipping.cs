using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain.Model
{
    public class Shipping : BaseModel
    {
        public ShippingPackage Package { get; }

        public decimal Price { get; }
    }
}
