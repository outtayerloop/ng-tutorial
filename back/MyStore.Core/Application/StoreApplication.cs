using AutoMapper;
using MyStore.Core.Data.Model;
using MyStore.Core.Data.Dto;
using MyStore.Core.Repository;

namespace MyStore.Core.Application
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository<Product> _productRepository;
        private readonly IStoreRepository<Shipping> _shippingRepository;

        public StoreApplication(IStoreRepository<Product> productRepository, IStoreRepository<Shipping> shippingRepository)
        {
            _productRepository = productRepository;
            _shippingRepository = shippingRepository;
            _mapper = Mapping.GetMapper();
        }

        public List<ProductDto> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAll();
            return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
        }

        public List<ShippingDto> GetAllShippings()
        {
            List<Shipping> shippings = _shippingRepository.GetAll();
            return shippings.Select(shipping => _mapper.Map<ShippingDto>(shipping)).ToList();
        }
    }
}
