using MyStore.Core.Data.Entity.Common;

namespace MyStore.Core.Data.Entity.Relation
{
    public class Shipping : BaseRelation
    {
        public ShippingPackage Package { get; set; }

        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Shipping shipping)
                return false;
            return shipping.Id == Id
                && shipping.Package == Package
                && shipping.Price == Price;
        }

        public override int GetHashCode()
            => base.GetHashCode();
    }
}
