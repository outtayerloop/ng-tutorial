using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using System;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class DescriptionRuleTests
    {
        private readonly DescriptionRule _descriptionRule;

        private static readonly uint _stubId = 1;

        private static readonly string _stubName = "stub";

        private static readonly decimal _stubPrice = 10M;

        private static readonly DateTime _stubDate = DateTime.Now;

        private static readonly bool _stubShippingState = false;

        public DescriptionRuleTests()
            => _descriptionRule = new DescriptionRule();

        [Fact]
        public void NullDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string? nullDescription = null;
            ProductModel stubProduct = GetStubProduct(nullDescription);

            ValidationStatus actualStatus = _descriptionRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NullDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string? nullDescription = null;
            ProductModel stubProduct = GetStubProduct(nullDescription);

            bool actualValidity = _descriptionRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void EmptyDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string emptyDescription = "";
            ProductModel stubProduct = GetStubProduct(emptyDescription);

            ValidationStatus actualStatus = _descriptionRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void EmptyDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string emptyDescription = "";
            ProductModel stubProduct = GetStubProduct(emptyDescription);

            bool actualValidity = _descriptionRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void FullWhiteSpaceDescription_ReturnsFailedDescriptionRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedDescriptionRule;
            string fullWhiteSpaceDescription = "      ";
            ProductModel stubProduct = GetStubProduct(fullWhiteSpaceDescription);

            ValidationStatus actualStatus = _descriptionRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void FullWhiteSpaceDescription_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string fullWhiteSpaceDescription = "      ";
            ProductModel stubProduct = GetStubProduct(fullWhiteSpaceDescription);

            bool actualValidity = _descriptionRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooLongDescription_ReturnsFailedDescriptionRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedDescriptionRule;
            string tooLongDescription = new('x', DescriptionRule._maxDescriptionLength + 1);
            ProductModel stubProduct = GetStubProduct(tooLongDescription);

            ValidationStatus actualStatus = _descriptionRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooLongDescription_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string tooLongDescription = new ('x', DescriptionRule._maxDescriptionLength + 1);
            ProductModel stubProduct = GetStubProduct(tooLongDescription);

            bool actualValidity = _descriptionRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string validDescription = "x";
            ProductModel stubProduct = GetStubProduct(validDescription);

            ValidationStatus actualStatus = _descriptionRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string validDescription = "x";
            ProductModel stubProduct = GetStubProduct(validDescription);

            bool actualValidity = _descriptionRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        private ProductModel GetStubProduct(string? description)
            => new(_stubId, _stubName, _stubPrice, description, _stubDate, _stubShippingState);
    }
}
