using AutoMapper;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Repository.Products;
using MyStore.Core.Repository.Shippings;

namespace MyStore.Core.Domain.Service.Store
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;
 
        public StoreApplication(
            IProductRepository productRepository,
            IShippingRepository shippingRepository)
        {
            _productRepository = productRepository;
            _shippingRepository = shippingRepository;
            _mapper = Mapping.GetMapper();
        }

        public List<ProductModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return products.Select(p => _mapper.Map<ProductModel>(p)).ToList();
        }

        public List<ShippingModel> GetAllShippings()
        {
            var shippings = _shippingRepository.GetAll();
            return shippings.Select(s => _mapper.Map<ShippingModel>(s)).ToList();
        }

        public List<Product> AddProductRange(List<Product> products)
            => _productRepository.AddRange(products);
    }
}
