namespace MyStore.Core.Domain.Model.Entity
{
    public abstract class BaseModel
    {
        public uint Id { get; }

        public BaseModel(uint id)
            => Id = id;
    }
}