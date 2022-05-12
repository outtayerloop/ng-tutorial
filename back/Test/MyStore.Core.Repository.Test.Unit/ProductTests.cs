using MyStore.Core.Data.Entity.Relation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Attributes;

namespace MyStore.Core.Repository.Test.Unit
{
    [TestCaseOrderer("Xunit.Microsoft.DependencyInjection.TestsOrder.TestPriorityOrderer", "Xunit.Microsoft.DependencyInjection")]
    [CollectionDefinition("Products")]
    [Collection("Products")]
    public class ProductTests : BaseTests
    {
        private readonly IStoreRepository<Product> _productRepository;

        public ProductTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture) : base(testOutputHelper, fixture)
            => _productRepository = fixture.GetService<IStoreRepository<Product>>(testOutputHelper);

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
    }
}