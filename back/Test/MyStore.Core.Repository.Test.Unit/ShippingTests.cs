using MyStore.Core.Data.Entity.Common;
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
    [CollectionDefinition("Shippings")]
    [Collection("Shippings")]
    public class ShippingTests : BaseTests
    {
        private readonly IStoreRepository<Shipping> _shippingRepository;

        public ShippingTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture) : base(testOutputHelper, fixture)
            => _shippingRepository = fixture.GetService<IStoreRepository<Shipping>>(testOutputHelper);

        [Fact, TestOrder(1)]
        public void WhenZeroShipping_DoesNotReturnNull()
        {
            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.NotNull(actualShippings);
        }

        [Fact, TestOrder(2)]
        public void WhenZeroShipping_ReturnsEmpty()
        {
            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.Empty(actualShippings);
        }

        [Fact, TestOrder(3)]
        public async Task WhenAtLeastOneShipping_CanGetAllShippings()
        {
            var expectedShippings = new List<Shipping>
            {
                new Shipping { Package = ShippingPackage.OverNight, Price = 25.99M },
                new Shipping { Package = ShippingPackage.TwoDay, Price = 9.99M },
                new Shipping { Package = ShippingPackage.Postal, Price = 2.99M },
            };
            await _context.AddRangeAsync(expectedShippings);
            await _context.SaveChangesAsync();

            List<Shipping> actualShippings = _shippingRepository.GetAll();

            Assert.True(expectedShippings.SequenceEqual(actualShippings));
        }
    }
}
