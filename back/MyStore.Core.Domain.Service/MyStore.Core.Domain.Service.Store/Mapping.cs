using AutoMapper;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Store
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
                        new ProductDto(product.Id, product.Name, product.Price, product.Description))
                    .ReverseMap();

                cfg.CreateMap<ProductDto, ProductModel>()
                    .ConstructUsing(product =>
                        new ProductModel(product.Id, product.Name, product.Price, product.Description));

                cfg.CreateMap<Shipping, ShippingDto>()
                    .ConstructUsing(shipping =>
                        new ShippingDto(shipping.Id, shipping.Package, shipping.Price));

                cfg.CreateMap<ValidationModel, ValidationDto>()
                    .ConstructUsing(validation =>
                        new ValidationDto(
                            Enum.GetName(typeof(ValidationStatus), validation.Status), 
                            validation.Message
                        ));
            });
            #if DEBUG
                // only during development, validate your mappings; remove it before release
                configuration.AssertConfigurationIsValid();
            #endif
            return configuration.CreateMapper();
        }
    }
}
