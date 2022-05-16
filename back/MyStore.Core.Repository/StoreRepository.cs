using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository
{
    public class StoreRepository<TRelation> : IStoreRepository<TRelation> where TRelation : BaseRelation
    {
        protected readonly DbSet<TRelation> _models;
        protected readonly MyStoreDbContext _context;

        public StoreRepository(MyStoreDbContext context)
        {
            _context = context;
            _models = _context.Set<TRelation>();
        }

        public List<TRelation> GetAll()
            => _models.ToList();
    }
}
