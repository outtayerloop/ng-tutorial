using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class PriceRuleTests
    {
        private readonly PriceRule _priceRule;

        private static readonly uint _stubId = 1;

        private static readonly string _stubName = "stub";

        private static readonly string? _stubDescription = "stub";

        public PriceRuleTests()
            => _priceRule = new PriceRule();

        [Fact]
        public void TooSmallPrice_ReturnsFailedPriceRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedPriceRule;
            decimal tooSmallPrice = PriceRule._minPrice - 1;
            ProductModel stubProduct = GetStubProduct(tooSmallPrice);

            ValidationStatus actualStatus = _priceRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooSmallPrice_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            decimal tooSmallPrice = PriceRule._minPrice - 1;
            ProductModel stubProduct = GetStubProduct(tooSmallPrice);

            bool actualValidity = _priceRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooBigPrice_ReturnsFailedPriceRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedPriceRule;
            decimal tooBigPrice = PriceRule._maxPrice + 1;
            ProductModel stubProduct = GetStubProduct(tooBigPrice);

            ValidationStatus actualStatus = _priceRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooBigPrice_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            decimal tooBigPrice = PriceRule._maxPrice + 1;
            ProductModel stubProduct = GetStubProduct(tooBigPrice);

            bool actualValidity = _priceRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidPrice_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            decimal validPrice = PriceRule._minPrice + 1;
            ProductModel stubProduct = GetStubProduct(validPrice);

            ValidationStatus actualStatus = _priceRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidPrice_ReturnsValidResult()
        {
            bool expectedValidity = true;
            decimal validPrice = PriceRule._minPrice + 1;
            ProductModel stubProduct = GetStubProduct(validPrice);

            bool actualValidity = _priceRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        private ProductModel GetStubProduct(decimal price)
            => new(_stubId, _stubName, price, _stubDescription);
    }
}
