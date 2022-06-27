using AutoMapper;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Repository;

namespace MyStore.Core.Domain.Service.Store
{
    public class ShoppingService : IShoppingService
    {
        private readonly IProductRepository _productRepository;
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;
 
        public ShoppingService(
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

        public List<ProductModel> AddProductRange(List<ProductModel> products)
        {
            List<Product> newProducts = products.Select(p => _mapper.Map<Product>(p)).ToList();
            List<Product> createdProducts = _productRepository.AddRange(newProducts);
            return createdProducts.Select(p => _mapper.Map<ProductModel>(p)).ToList();
        }
    }
}
