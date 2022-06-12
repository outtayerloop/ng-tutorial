using AutoMapper;
using MyStore.Core.Domain.Service.Extensions.Mapping;

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
                cfg.CreateProductMap();
                cfg.CreateShippingMap();
                cfg.CreateValidationMap();
            });
            #if DEBUG
                // only during development, validate your mappings; remove it before release
                configuration.AssertConfigurationIsValid();
            #endif
            return configuration.CreateMapper();
        }
    }
}
