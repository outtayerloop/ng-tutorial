using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository.Products
{
    public class ProductRepository : StoreRepository<Product>, IProductRepository
    {
        public ProductRepository(MyStoreDbContext context) : base(context)
        {
        }

        public List<Product> AddRange(List<Product> products)
        {
            if (products == null)
                throw new ArgumentNullException("Can not insert null entity range in database.");
            products.RemoveAll(p => p == null);
            products.RemoveAll(p => GetByName(p.Name) != null);
            if (products.Count > 0)
            {
                products.ForEach(p =>
                {
                    p.Id = 0;
                    p.Shipped = false;
                });
                _models.AddRange(products);
                _context.SaveChanges();
            }
            return products;
        }

        private Product? GetByName(string name)
            => _models.FirstOrDefault(p => p.Name == name);
    }
}
