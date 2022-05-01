using MyStore.Core.Domain.Common;

namespace MyStore.Core.Domain
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }
    }
}
