using MyStore.Core.Domain;

namespace MyStore.Core.Repository
{
    public interface IStoreRepository<T> where T : BaseModel
    {
        List<T> GetAll();
    }
}
