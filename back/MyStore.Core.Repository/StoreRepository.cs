using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository
{
    public class StoreRepository<T> : IStoreRepository<T> where T : BaseRelation
    {
        private readonly DbSet<T> _models;
        private readonly MyStoreDbContext _context;

        public StoreRepository(MyStoreDbContext context)
        {
            _context = context;
            _models = _context.Set<T>();
        }

        public List<T> GetAll()
            => _models.ToList();

        public List<T> AddRange(List<T> entities)
        {
            _models.AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
    }
}
