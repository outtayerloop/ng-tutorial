namespace MyStore.Core.Data.Dto
{
    public abstract record BaseDto(uint Id);

    public sealed record ProductDto(uint Id, string Name, decimal Price, string? Description) : BaseDto(Id);

    public sealed record ShippingDto(uint Id, ShippingPackage Package, decimal Price) : BaseDto(Id);
}