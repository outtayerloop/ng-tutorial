using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository
{
    public class StoreRepository<T> : IStoreRepository<T> where T : BaseRelation
    {
        private readonly DbSet<T> _models;

        public StoreRepository(MyStoreDbContext context)
            => _models = context.Set<T>();

        public List<T> GetAll()
            => _models.ToList();
    }
}
