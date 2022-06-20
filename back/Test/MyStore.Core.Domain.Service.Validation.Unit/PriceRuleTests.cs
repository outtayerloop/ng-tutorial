using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class PriceRuleTests
    {
        private readonly PriceRule _priceRule;

        public PriceRuleTests()
            => _priceRule = new PriceRule();

        [Fact]
        public void NullPrice_ReturnsFailedPriceRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedPriceRule;
            double? nullPrice = null;

            ValidationStatus actualStatus = _priceRule.Validate(nullPrice).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NullPrice_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            double? nullPrice = null;

            bool actualValidity = _priceRule.Validate(nullPrice).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooSmallPrice_ReturnsFailedPriceRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedPriceRule;
            double tooSmallPrice = (double)PriceRule._minPrice - 1;

            ValidationStatus actualStatus = _priceRule.Validate(tooSmallPrice).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooSmallPrice_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            double tooSmallPrice = (double)PriceRule._minPrice - 1;

            bool actualValidity = _priceRule.Validate(tooSmallPrice).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooBigPrice_ReturnsFailedPriceRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedPriceRule;
            double tooBigPrice = (double)PriceRule._maxPrice + 1;

            ValidationStatus actualStatus = _priceRule.Validate(tooBigPrice).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooBigPrice_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            double tooBigPrice = (double)PriceRule._maxPrice + 1;

            bool actualValidity = _priceRule.Validate(tooBigPrice).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidPrice_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            double validPrice = (double)PriceRule._minPrice + 1;

            ValidationStatus actualStatus = _priceRule.Validate(validPrice).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidPrice_ReturnsValidResult()
        {
            bool expectedValidity = true;
            double validPrice = (double)PriceRule._minPrice + 1;

            bool actualValidity = _priceRule.Validate(validPrice).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }
    }
}
