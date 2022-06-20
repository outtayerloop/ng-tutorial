using MyStore.Core.Data.Entity.Common;

namespace MyStore.Core.Data.Entity.Dto
{
    public abstract record BaseDto(uint Id);

    public sealed record ProductDto(uint Id, string Name, decimal Price, string? Description) : BaseDto(Id);

    public sealed record ShippingDto(uint Id, ShippingPackage Package, decimal Price) : BaseDto(Id);

    public sealed record RuleResultDto(bool IsValid, string Status, string Message);

    public sealed record ValidationResultDto(bool IsValid, List<RuleResultDto> RuleResults);
}