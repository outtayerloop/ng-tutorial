using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain
{
    public class Cart : BaseModel
    {
        public Cart()
            => Products = new List<Product>();

        public List<Product> Products { get; set; }
    }
}
