using MyStore.Core.Database;
using MyStore.Core.Domain;
using MyStore.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;
using Xunit.Microsoft.DependencyInjection.Attributes;

namespace MyStore.UnitTests
{
    [TestCaseOrderer("Xunit.Microsoft.DependencyInjection.TestsOrder.TestPriorityOrderer", "Xunit.Microsoft.DependencyInjection")]
    public class ProductTests : TestBed<UnitTestsFixture>
    {
        private readonly MyStoreDbContext _context;

        private readonly IStoreRepository<Product> _productRepository;

        public ProductTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture) 
            : base(testOutputHelper, fixture)
        {
            _context = ContextManager.GetContext();
            _productRepository = fixture.GetService<IStoreRepository<Product>>(testOutputHelper);
        }

        [Fact, TestOrder(1)]
        public void WhenZeroProduct_DoesNotReturnNull()
        {
            List<Product> actualProducts = _productRepository.GetAll();

            Assert.NotNull(actualProducts);
        }

        [Fact, TestOrder(2)]
        public void WhenZeroProduct_ReturnsEmpty()
        {
            List<Product> actualProducts = _productRepository.GetAll();

            Assert.Empty(actualProducts);
        }

        [Fact, TestOrder(3)]
        public async Task WhenAtLeastOneProduct_CanGetAllProducts()
        {
            var expectedProducts = new List<Product>
            {
                new Product { Name = "product1", Description = "product1Description", Price = 100 },
                new Product { Name = "product2", Description = "product2Description", Price = 200 },
                new Product { Name = "product3", Description = "product3Description", Price = 300 }
            };
            await _context.AddRangeAsync(expectedProducts);
            await _context.SaveChangesAsync();

            List<Product> actualProducts = _productRepository.GetAll();

            Assert.True(expectedProducts.SequenceEqual(actualProducts));
        }

        [Fact, TestOrder(4)]
        public void TwoSameProducts_EqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.True(areEqual);
        }

        [Fact, TestOrder(5)]
        public void TwoProducts_WhenDifferentIds_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProductWithDifferentId(stubProduct1);

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(6)]
        public void TwoProducts_WhenDifferentNames_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Name = stubProduct1.Name + "x";

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(7)]
        public void TwoProducts_WhenDifferentDescriptions_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Description = stubProduct1.Description + "x";

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(8)]
        public void TwoProducts_WhenDifferentPrices_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Price = stubProduct1.Price + 1;

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(9)]
        public void WhenSecondProductIsNull_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            Product? stubProduct2 = null;

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        private Product GetProduct()
        {
            return new Product
            { 
                Id = 1, 
                Name = "product1", 
                Description = "product1Description", 
                Price = 100
            };
        }

        private Product GetProductWithDifferentId(Product product)
        {
            return new Product
            {
                Id = product.Id + 1,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
        }
    }
}