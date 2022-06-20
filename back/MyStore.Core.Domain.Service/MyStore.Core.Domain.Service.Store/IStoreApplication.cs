using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Store
{
    public interface IStoreApplication
    {
        List<ProductModel> GetAllProducts();

        List<ShippingModel> GetAllShippings();

        List<Product> AddProductRange(List<Product> products);
    }
}
