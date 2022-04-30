using MyStore.Core.Domain;
using MyStore.Core.Domain.Common;

namespace MyStore.Core.Repository
{
    public interface IStoreRepository<T> where T : BaseModel
    {
        List<T> GetAll();

        Cart? GetById(uint id);

        Cart? Update(CartDto cart);
    }
}
