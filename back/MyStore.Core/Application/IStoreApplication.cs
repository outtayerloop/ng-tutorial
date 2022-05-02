using MyStore.Core.Domain;

namespace MyStore.Core.Application
{
    public interface IStoreApplication
    {
        List<ProductDto> GetAllProducts();
    }
}
