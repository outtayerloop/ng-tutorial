using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Repository;
using MyStore.Core.Repository.Products;

namespace MyStore.Core.Domain.Service.Store
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository<Shipping> _shippingRepository;
 
        public StoreApplication(
            IProductRepository productRepository, 
            IStoreRepository<Shipping> shippingRepository)
        {
            _productRepository = productRepository;
            _shippingRepository = shippingRepository;
        }

        public List<Product> GetAllProducts()
            => _productRepository.GetAll();

        public List<Shipping> GetAllShippings()
            => _shippingRepository.GetAll();

        public List<Product> AddProductRange(List<Product> products)
            => _productRepository.AddRange(products);
    }
}
