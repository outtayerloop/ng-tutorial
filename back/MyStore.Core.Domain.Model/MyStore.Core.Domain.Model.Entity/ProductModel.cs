namespace MyStore.Core.Domain.Model.Entity
{
    public class ProductModel : BaseModel
    {
        public string Name { get; }

        public decimal Price { get; }

        public string? Description { get; }

        public DateTime ShippingDate { get; }

        public bool Shipped { get; }

        public ProductModel(
            uint id, 
            string name, 
            decimal price, 
            string? description, 
            DateTime shippingDate,
            bool shipped) 
        : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
            ShippingDate = shippingDate;
            Shipped = shipped;
        }
    }
}
