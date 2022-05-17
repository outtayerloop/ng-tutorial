using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Repository;

namespace MyStore.Core.Domain.Service.Store
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IStoreRepository<Product> _productRepository;
        private readonly IStoreRepository<Shipping> _shippingRepository;
 
        public StoreApplication(
            IStoreRepository<Product> productRepository, 
            IStoreRepository<Shipping> shippingRepository)
        {
            _productRepository = productRepository;
            _shippingRepository = shippingRepository;
        }

        public List<Product> GetAllProducts()
            => _productRepository.GetAll();

        public List<Shipping> GetAllShippings()
            => _shippingRepository.GetAll();
    }
}
