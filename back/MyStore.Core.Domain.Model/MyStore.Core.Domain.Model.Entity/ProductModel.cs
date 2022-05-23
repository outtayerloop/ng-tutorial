using MyStore.Core.Data.Entity.Constants;

namespace MyStore.Core.Domain.Model.Entity
{
    public class ProductModel : BaseModel
    {
        public string Name { get; }

        public decimal Price { get; }

        public string? Description { get; }

        public ProductModel(uint id, string name, decimal price, string? description) : base(id)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public bool HasValidName()
        {
            return !string.IsNullOrEmpty(Name)
                && !string.IsNullOrWhiteSpace(Name)
                && Name.Length <= ProductConstants.MaxNameLenth;
        }

        public bool HasValidPrice()
        {
            return Price >= ProductConstants.MinPrice
                && Price <= ProductConstants.MaxPrice;
        }

        public bool HasValidDescription()
        {
            return Description == null
                || (
                    !string.IsNullOrWhiteSpace(Description) 
                    && Description.Length <= ProductConstants.MaxDescriptionLenth
                );
        }
    }
}
