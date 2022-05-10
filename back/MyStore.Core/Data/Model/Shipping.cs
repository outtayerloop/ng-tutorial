namespace MyStore.Core.Data.Model
{
    public class Shipping : BaseModel
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
    }
}
