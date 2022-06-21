using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using System;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class NameRuleTests
    {
        private readonly NameRule _nameRule;

        private static readonly uint _stubId = 1;

        private static readonly string? _stubDescription = "stub";

        private static readonly decimal _stubPrice = 10M;

        private static readonly DateTime _stubDate = DateTime.Now;

        public NameRuleTests()
            => _nameRule = new NameRule();

        [Fact]
        public void NullName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string? nullName = null;
            ProductModel stubProduct = GetStubProduct(nullName);

            ValidationStatus actualStatus = _nameRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NullName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string? nullName = null;
            ProductModel stubProduct = GetStubProduct(nullName);

            bool actualValidity = _nameRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void EmptyName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string emptyName = "";
            ProductModel stubProduct = GetStubProduct(emptyName);

            ValidationStatus actualStatus = _nameRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void EmptyName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string emptyName = "";
            ProductModel stubProduct = GetStubProduct(emptyName);

            bool actualValidity = _nameRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void FullWhiteSpaceName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string fullWhiteSpaceName = "      ";
            ProductModel stubProduct = GetStubProduct(fullWhiteSpaceName);

            ValidationStatus actualStatus = _nameRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void FullWhiteSpaceName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string fullWhiteSpaceName = "      ";
            ProductModel stubProduct = GetStubProduct(fullWhiteSpaceName);

            bool actualValidity = _nameRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooLongName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string tooLongName = new('x', NameRule._maxNameLength + 1);
            ProductModel stubProduct = GetStubProduct(tooLongName);

            ValidationStatus actualStatus = _nameRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooLongName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string tooLongName = new('x', NameRule._maxNameLength + 1);
            ProductModel stubProduct = GetStubProduct(tooLongName);

            bool actualValidity = _nameRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidName_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string validName = "x";
            ProductModel stubProduct = GetStubProduct(validName);

            ValidationStatus actualStatus = _nameRule.Validate(stubProduct).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidName_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string validName = "x";
            ProductModel stubProduct = GetStubProduct(validName);

            bool actualValidity = _nameRule.Validate(stubProduct).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        private ProductModel GetStubProduct(string? name)
            => new(_stubId, name!, _stubPrice, _stubDescription, _stubDate);
    }
}