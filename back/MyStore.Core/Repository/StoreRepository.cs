using AutoMapper;
using MyStore.Core.Application;
using MyStore.Core.Domain;
using MyStore.Core.Domain.Common;

namespace MyStore.Core.Repository
{
    public class StoreRepository<T> : IStoreRepository<T> where T : BaseModel
    {
        private readonly IMapper _mapper;

        public StoreRepository()
            => _mapper = Mapping.GetMapper();

        private static readonly List<T> _products = new List<T>
        {
            new Product { Id = 1, Name = "Phone XL", Price = 799, Description = "A large phone with one of the best screens" } as T,
            new Product { Id = 2, Name = "Phone Mini", Price = 699, Description = "A great phone with one of the best cameras" } as T,
            new Product { Id = 3, Name = "Phone Standard", Price = 299 } as T
        };

        private static readonly List<Cart> _carts = new List<Cart>
        {
            new Cart{ Id = 1 }
        };

        public List<T> GetAll()
            => _products;

        public Cart? GetById(uint id)
            => _carts.Find(c => c.Id == id);

        public Cart? Update(CartDto cart)
        {
            Cart? foundCart = _carts.Find(c => c.Id == cart.Id);
            if(foundCart != null)
            {
                foundCart.Products = cart.Products
                    .Select(c => _mapper.Map<Product>(c))
                    .ToList();
            }
            return foundCart;
        }
    }
}
