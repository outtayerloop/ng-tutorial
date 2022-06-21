using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository
{
    public interface IStoreRepository<TRelation> where TRelation : BaseRelation
    {
        List<TRelation> GetAll();
    }
}
