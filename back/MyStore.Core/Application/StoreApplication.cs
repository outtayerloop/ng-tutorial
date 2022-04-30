using AutoMapper;
using MyStore.Core.Domain;
using MyStore.Core.Repository;

namespace MyStore.Core.Application
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IMapper _mapper;
        private readonly IStoreRepository<Product> _productRepository;

        public StoreApplication(IStoreRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _mapper = Mapping.GetMapper();
        }

        public List<ProductDto> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAll();
            return products.Select(product => _mapper.Map<ProductDto>(product)).ToList();
        }
    }
}
