using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository
{
    public interface IStoreRepository<T> where T : BaseRelation
    {
        List<T> GetAll();
    }
}
