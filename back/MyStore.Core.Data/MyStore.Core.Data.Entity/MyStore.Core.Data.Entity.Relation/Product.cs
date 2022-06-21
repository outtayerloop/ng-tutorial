namespace MyStore.Core.Data.Entity.Relation
{
    public class Product : BaseRelation
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public DateTime ShippingDate { get; set; }

        public bool Shipped { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Product product)
                return false;
            return product.Id == Id
                && product.Name == Name 
                && product.Price == Price
                && product.Description == Description
                && product.ShippingDate.CompareTo(ShippingDate) == 0
                && product.Shipped == Shipped;
        }
    }
}
