using AutoMapper;
using MyStore.Core.Domain;

namespace MyStore.Core.Application
{
    public static class Mapping
    {
        private static IMapper _mapper;

        public static IMapper GetMapper()
        {
            if (_mapper == null)
                _mapper = CreateMapper();
            return _mapper;
        }

        private static IMapper CreateMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>()
                    .ConstructUsing(product =>
                        new ProductDto(product.Id, product.Name, product.Price, product.Description));
            });
            // only during development, validate your mappings; remove it before release
            configuration.AssertConfigurationIsValid();
            return configuration.CreateMapper();
        }
    }
}
