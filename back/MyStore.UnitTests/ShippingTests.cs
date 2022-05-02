using MyStore.Core.Database;
using MyStore.Core.Domain;
using MyStore.Core.Domain.Model;
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
    public class ShippingTests : TestBed<UnitTestsFixture>
    {
        private readonly MyStoreDbContext _context;

        private readonly IStoreRepository<Shipping> _shippingRepository;

        public ShippingTests(ITestOutputHelper testOutputHelper, UnitTestsFixture fixture)
            : base(testOutputHelper, fixture)
        {
            _context = ContextManager.GetContext();
            _shippingRepository = fixture.GetService<IStoreRepository<Shipping>>(testOutputHelper);
        }

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
        public async Task WhenAtLeastOneShipping_CanGetAllShipping()
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

        [Fact, TestOrder(4)]
        public void TwoSameShippings_EqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.True(areEqual);
        }

        [Fact, TestOrder(5)]
        public void TwoShippings_WhenDifferentIds_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShippingWithDifferentId(stubShipping1);

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(6)]
        public void TwoShippings_WhenDifferentPackages_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();
            stubShipping1.Package = ShippingPackage.TwoDay;

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(8)]
        public void TwoShippings_WhenDifferentPrices_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();
            stubShipping2.Price = stubShipping1.Price + 1;

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact, TestOrder(9)]
        public void WhenSecondShippingIsNull_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            Shipping? stubShipping2 = null;

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        /// <summary>
        /// Returns a new <see cref="Shipping"/> with its package initialized to
        /// <see cref="ShippingPackage.OverNight"/>.
        /// </summary>
        /// <returns></returns>
        private Shipping GetShipping()
        {
            return new Shipping
            {
                Id = 1,
                Package = ShippingPackage.OverNight,
                Price = 29.99M
            };
        }

        private Shipping GetShippingWithDifferentId(Shipping shipping)
        {
            return new Shipping
            {
                Id = shipping.Id + 1,
                Package = shipping.Package,
                Price = shipping.Price
            };
        }
    }
}
