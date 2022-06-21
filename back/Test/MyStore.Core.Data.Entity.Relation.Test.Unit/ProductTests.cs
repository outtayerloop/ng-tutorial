using MyStore.Core.Data.Entity.Relation;
using Xunit;

namespace MyStore.Core.Repository.Test.Unit
{
    public class ProductTests
    {
        [Fact]
        public void TwoSameProducts_EqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.True(areEqual);
        }

        [Fact]
        public void TwoProducts_WhenDifferentIds_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProductWithDifferentId(stubProduct1);

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact]
        public void TwoProducts_WhenDifferentNames_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Name = stubProduct1.Name + "x";

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact]
        public void TwoProducts_WhenDifferentDescriptions_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Description = stubProduct1.Description + "x";

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact]
        public void TwoProducts_WhenDifferentPrices_DoNotEqualEachOther()
        {
            var stubProduct1 = GetProduct();
            var stubProduct2 = GetProduct();
            stubProduct2.Price = stubProduct1.Price + 1;

            bool areEqual = stubProduct1.Equals(stubProduct2);

            Assert.False(areEqual);
        }

        [Fact]
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