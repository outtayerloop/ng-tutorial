using AutoMapper;
using MyStore.Core.Data.Entity.Model;
using MyStore.Core.Data.Entity.Dto;

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

                cfg.CreateMap<Shipping, ShippingDto>()
                    .ConstructUsing(shipping =>
                        new ShippingDto(shipping.Id, shipping.Package, shipping.Price));
            });
            #if DEBUG
                // only during development, validate your mappings; remove it before release
                configuration.AssertConfigurationIsValid();
            #endif
            return configuration.CreateMapper();
        }
    }
}
