using MyStore.Core.Data.Entity.Common;
using MyStore.Core.Data.Entity.Relation;
using Xunit;

namespace MyStore.Core.Repository.Test.Unit
{
    public class ShippingTests
    {
        [Fact]
        public void TwoSameShippings_EqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.True(areEqual);
        }

        [Fact]
        public void TwoShippings_WhenDifferentIds_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShippingWithDifferentId(stubShipping1);

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact]
        public void TwoShippings_WhenDifferentPackages_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();
            stubShipping1.Package = ShippingPackage.TwoDay;

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact]
        public void TwoShippings_WhenDifferentPrices_DoNotEqualEachOther()
        {
            var stubShipping1 = GetShipping();
            var stubShipping2 = GetShipping();
            stubShipping2.Price = stubShipping1.Price + 1;

            bool areEqual = stubShipping1.Equals(stubShipping2);

            Assert.False(areEqual);
        }

        [Fact]
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
