namespace MyStore.Core.Domain.Model.Entity
{
    public class ProductModel : BaseModel
    {
        public string Name { get; }

        public decimal Price { get; }

        public string? Description { get; }

        public DateTime Date { get; }

        public ProductModel(
            uint id, 
            string name, 
            decimal price, 
            string? description, 
            DateTime date
        ) : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
            Date = date;
        }
    }
}
