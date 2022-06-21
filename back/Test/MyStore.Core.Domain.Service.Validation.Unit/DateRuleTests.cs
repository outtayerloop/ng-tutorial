using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using System;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class DateRuleTests
    {
        private readonly DateRule _dateRule;

        private static readonly uint _stubId = 1;

        private static readonly string _stubName = "stub";

        private static readonly string _stubDescription = "stub";

        private static readonly decimal _stubPrice = 10M;

        public DateRuleTests()
            => _dateRule = new DateRule();

        [Fact]
        public void AlreadyShippedProduct_WithExpiredShippingDelay_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            bool alreadyShipped = true;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay + 1);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, alreadyShipped);

            ValidationStatus actualStatus = _dateRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void AlreadyShippedProduct_WithExpiredShippingDelay_ReturnsValidResult()
        {
            bool expectedValidity = true;
            bool alreadyShipped = true;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay + 1);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, alreadyShipped);

            bool actualValidity = _dateRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void NotShippedProduct_WithExpiredShippingDelay_ReturnsFailedDateRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedDateRule;
            bool notShipped = false;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay + 1);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, notShipped);

            ValidationStatus actualStatus = _dateRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NotShippedProduct_WithExpiredShippingDelay_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            bool notShipped = false;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay + 1);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, notShipped);

            bool actualValidity = _dateRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void NotShippedProduct_WithValidShippingDelay_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            bool notShipped = false;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, notShipped);

            ValidationStatus actualStatus = _dateRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NotShippedProduct_WithValidShippingDelay_ReturnsValidResult()
        {
            bool expectedValidity = true;
            bool notShipped = false;
            DateTime expiredShippingDelay = DateTime.Now - TimeSpan.FromDays(DateRule._productShippingMaxDelay);
            ProductModel stubProduct = GetStubProduct(expiredShippingDelay, notShipped);

            bool actualValidity = _dateRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        private ProductModel GetStubProduct(DateTime shippingDate, bool shipped)
            => new(_stubId, _stubName, _stubPrice, _stubDescription, shippingDate, shipped);
    }
}
