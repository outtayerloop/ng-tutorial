using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository.Products
{
    public interface IProductRepository : IStoreRepository<Product>
    {
        List<Product> AddRange(List<Product> entities);
    }
}
