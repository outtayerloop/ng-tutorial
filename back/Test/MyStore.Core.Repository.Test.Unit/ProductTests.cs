using Microsoft.EntityFrameworkCore;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Repository.Products;
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
    public class ProductTests : BaseRepositoryTests
    {
        private readonly IProductRepository _productRepository;

        public ProductTests(ITestOutputHelper testOutputHelper, RepositoryTestsFixture fixture) : base(testOutputHelper, fixture)
            => _productRepository = fixture.GetService<IProductRepository>(testOutputHelper)!;

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
            var expectedProducts = GetProductList();
            await _context.AddRangeAsync(expectedProducts);
            await _context.SaveChangesAsync();

            List<Product> actualProducts = _productRepository.GetAll();

            Assert.True(expectedProducts.SequenceEqual(actualProducts));
        }

        /*[Fact, TestOrder(4)]
        public void WhenZeroProduct_DoesNotAddAnyProduct()
        {
            var emptyProductList = new List<Product>();

            _productRepository.AddRange(emptyProductList);
            DbSet<Product> actualProducts = _context.Products;

            Assert.Empty(actualProducts);
        }*/

        [Fact, TestOrder(5)]
        public void WhenAtLeastOneProduct_InsertsNewLinesInDatabase()
        {
            List<Product> products = GetProductList();
            int expectedLineCount = products.Count;

            _productRepository.AddRange(products);
            int actualLineCount = _context.Products.Count();

            Assert.Equal(actualLineCount, expectedLineCount);
        }

        [Fact, TestOrder(6)]
        public void WhenAtLeastOneProduct_SetsIdForEachNewProduct()
        {
            List<Product> products = GetProductList();

            _productRepository.AddRange(products);
            DbSet<Product> actualProducts = _context.Products;
            bool haveAllBeenIdentified = actualProducts.All(p => p.Id > 0);

            Assert.True(haveAllBeenIdentified);
        }

        /*[Fact, TestOrder(7)]
        public void WhenAtLeastOneProduct_AddsInputProducts()
        {
            List<Product> expectedProducts = GetProductList();

            _productRepository.AddRange(expectedProducts);
            List<Product> actualProducts = _context.Products.ToList();
            for(int i = 0; i < expectedProducts.Count; ++i)
                expectedProducts[i].Id = actualProducts[i].Id;

            Assert.True(actualProducts.SequenceEqual(expectedProducts));
        }*/

        private List<Product> GetProductList()
        {
            return new List<Product>
            {
                new Product { Name = "product1", Description = "product1Description", Price = 100 },
                new Product { Name = "product2", Description = "product2Description", Price = 200 },
                new Product { Name = "product3", Description = "product3Description", Price = 300 }
            };
        }
    }
}