using MyStore.Core.Data.Context.Postgres;
using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Repository.Shippings
{
    public class ShippingRepository : StoreRepository<Shipping>, IShippingRepository
    {
        public ShippingRepository(MyStoreDbContext context) : base(context)
        {
        }
    }
}
