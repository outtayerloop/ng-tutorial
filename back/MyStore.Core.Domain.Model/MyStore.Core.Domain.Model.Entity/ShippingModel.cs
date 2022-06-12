using MyStore.Core.Data.Entity.Common;

namespace MyStore.Core.Domain.Model.Entity
{
    public class ShippingModel : BaseModel
    {
        public ShippingPackage Package { get; }

        public decimal Price { get; }

        public ShippingModel(uint id, ShippingPackage package, decimal price) : base(id)
        {
            Package = package;
            Price = price;
        }
    }
}
