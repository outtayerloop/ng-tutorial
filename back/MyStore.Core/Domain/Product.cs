using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Product product)
                return false;
            return product.Id == Id
                && product.Name == Name 
                && product.Price == Price
                && product.Description == Description;
        }
    }
}
