using MyStore.Core.Data.Entity.Dto;

namespace MyStore.Core.Application
{
    public interface IStoreApplication
    {
        List<ProductDto> GetAllProducts();

        List<ShippingDto> GetAllShippings();
    }
}
