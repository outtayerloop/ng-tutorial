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

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _models.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }
    }
}
