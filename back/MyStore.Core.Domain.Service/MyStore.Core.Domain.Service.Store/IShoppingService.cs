using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Store
{
    public interface IShoppingService
    {
        List<ProductModel> GetAllProducts();

        List<ShippingModel> GetAllShippings();

        List<ProductModel> AddProductRange(List<ProductModel> products);
    }
}
