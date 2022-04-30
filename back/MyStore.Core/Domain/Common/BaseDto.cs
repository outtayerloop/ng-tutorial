namespace MyStore.Core.Domain.Common
{
    public abstract class BaseDto
    {
        public BaseDto(uint id)
            => Id = id;

        public uint Id { get; }
    }
}
