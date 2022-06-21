using MyStore.Core.Data.Entity.Common;
using MyStore.Core.Data.Entity.Relation;
using MyStore.Core.Repository.Shippings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MyStore.Core.Repository.Test.Unit
{
    [CollectionDefinition("Shippings")]
    [Collection("Shippings")]
    public class ShippingTests : BaseRepositoryTests
    {
        private readonly IStoreRepository<Shipping> _shippingRepository;

        public ShippingTests(ITestOutputHelper testOutputHelper, RepositoryTestsFixture fixture) : base(testOutputHelper, fixture)
            => _shippingRepository = fixture.GetService<IShippingRepository>(testOutputHelper)!;

        [Fact]
        public void WhenZeroShipping_DoesNotReturnNull()
        {
            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.NotNull(actualShippings);
        }

        [Fact]
        public void WhenZeroShipping_ReturnsEmpty()
        {
            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.Empty(actualShippings);
        }

        [Fact]
        public async Task WhenAtLeastOneShipping_CanGetAllShippings()
        {
            var expectedShippings = new List<Shipping>
            {
                new Shipping { Package = ShippingPackage.OverNight, Price = 25.99M },
                new Shipping { Package = ShippingPackage.TwoDay, Price = 9.99M },
                new Shipping { Package = ShippingPackage.Postal, Price = 2.99M }
            };
            await _context.AddRangeAsync(expectedShippings);
            await _context.SaveChangesAsync();

            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.True(expectedShippings.SequenceEqual(actualShippings));
        }
    }
}
