using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class NameRuleTests
    {
        private readonly NameRule _nameRule;

        public NameRuleTests()
            => _nameRule = new NameRule();

        [Fact]
        public void NullName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string? nullName = null;

            ValidationStatus actualStatus = _nameRule.Validate(nullName).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NullName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string? nullName = null;

            bool actualValidity = _nameRule.Validate(nullName).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void EmptyName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string emptyName = "";

            ValidationStatus actualStatus = _nameRule.Validate(emptyName).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void EmptyName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string emptyName = "";

            bool actualValidity = _nameRule.Validate(emptyName).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void FullWhiteSpaceName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string fullWhiteSpaceName = "      ";

            ValidationStatus actualStatus = _nameRule.Validate(fullWhiteSpaceName).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void FullWhiteSpaceName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string fullWhiteSpaceName = "      ";

            bool actualValidity = _nameRule.Validate(fullWhiteSpaceName).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooLongName_ReturnsFailedNameRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedNameRule;
            string tooLongName = new('x', NameRule._maxNameLength + 1);

            ValidationStatus actualStatus = _nameRule.Validate(tooLongName).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooLongName_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string tooLongName = new('x', NameRule._maxNameLength + 1);

            bool actualValidity = _nameRule.Validate(tooLongName).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidName_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string validName = "x";

            ValidationStatus actualStatus = _nameRule.Validate(validName).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidName_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string validName = "x";

            bool actualValidity = _nameRule.Validate(validName).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }
    }
}