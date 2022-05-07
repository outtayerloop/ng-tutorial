using MyStore.Core.Domain.Dto;

namespace MyStore.Core.Application
{
    public interface IStoreApplication
    {
        List<ProductDto> GetAllProducts();

        List<ShippingDto> GetAllShippings();
    }
}
