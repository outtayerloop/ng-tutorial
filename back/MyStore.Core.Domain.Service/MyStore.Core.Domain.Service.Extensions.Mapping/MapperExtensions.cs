using AutoMapper;
using MyStore.Core.Data.Entity.Dto;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Domain.Model.Entity;

namespace MyStore.Core.Domain.Service.Extensions.Mapping
{
    public static class MapperExtensions
    {
        private static readonly string _inputDateTimeFormat = "yyyy/MM/dd HH:mm";

        private static readonly string _outputDateTimeFormat = "dd/MM/yyyy HH:mm";

        public static void CreateProductMap(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductDto>()
                .ConstructUsing(product =>
                    new ProductDto(product.Id, product.Name, product.Price, product.Description, product.ShippingDate.ToString(_outputDateTimeFormat), product.Shipped));
            
            cfg.CreateMap<ProductDto, ProductModel>()
                .ConstructUsing(dto =>
                    new ProductModel(dto.Id, dto.Name, dto.Price, dto.Description, DateTime.ParseExact(dto.ShippingDate, _inputDateTimeFormat, null), dto.Shipped))
                .ReverseMap()
                .ConstructUsing(model =>
                    new ProductDto(model.Id, model.Name, model.Price, model.Description, model.ShippingDate.ToString(_outputDateTimeFormat), model.Shipped));

            cfg.CreateMap<Product, ProductModel>()
                .ConstructUsing(product =>
                    new ProductModel(product.Id, product.Name, product.Price, product.Description, product.ShippingDate, product.Shipped))
                .ReverseMap();
        }

        public static void CreateShippingMap(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Shipping, ShippingDto>()
                .ConstructUsing(shipping =>
                    new ShippingDto(shipping.Id, shipping.Package, shipping.Price));

            cfg.CreateMap<Shipping, ShippingModel>()
                .ConstructUsing(shipping =>
                    new ShippingModel(shipping.Id, shipping.Package, shipping.Price));

            cfg.CreateMap<ShippingModel, ShippingDto>()
                .ConstructUsing(shipping =>
                    new ShippingDto(shipping.Id, shipping.Package, shipping.Price));
        }

        public static void CreateValidationMap(this IMapperConfigurationExpression cfg)
        {
            IMapper ruleResultmapper = new MapperConfiguration(config => config.CreateRuleResultMap()).CreateMapper();

            cfg.CreateMap<ValidationResult, ValidationResultDto>()
                .ConstructUsing(validation =>
                    new ValidationResultDto(
                        validation.IsValid,
                        validation.RuleResults.Select(ruleResult => ruleResultmapper.Map<RuleResultDto>(ruleResult)).ToList()
                    ))
                .ForMember(
                        dest => dest.RuleResults,
                        opt => opt.Ignore()
                    );
        }

        private static void CreateRuleResultMap(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<RuleResult, RuleResultDto>()
                .ConstructUsing(result =>
                    new RuleResultDto(
                        result.IsValid,
                        Enum.GetName(typeof(ValidationStatus), result.Status)!,
                        result.Message
                    ));
        }
    }
}
