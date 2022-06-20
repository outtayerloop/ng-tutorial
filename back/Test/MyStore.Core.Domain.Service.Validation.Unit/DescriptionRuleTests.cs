using MyStore.Core.Domain.Model.Entity;
using MyStore.Core.Domain.Service.Validation.Rules;
using Xunit;

namespace MyStore.Core.Domain.Service.Validation.Unit
{
    public class DescriptionRuleTests
    {
        private readonly DescriptionRule _descriptionRule;

        public DescriptionRuleTests()
            => _descriptionRule = new DescriptionRule();

        [Fact]
        public void NullDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string? nullDescription = null;

            ValidationStatus actualStatus = _descriptionRule.Validate(nullDescription).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void NullDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string? nullDescription = null;

            bool actualValidity = _descriptionRule.Validate(nullDescription).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void EmptyDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string emptyDescription = "";

            ValidationStatus actualStatus = _descriptionRule.Validate(emptyDescription).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void EmptyDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string emptyDescription = "";

            bool actualValidity = _descriptionRule.Validate(emptyDescription).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void FullWhiteSpaceDescription_ReturnsFailedDescriptionRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedDescriptionRule;
            string fullWhiteSpaceDescription = "      ";

            ValidationStatus actualStatus = _descriptionRule.Validate(fullWhiteSpaceDescription).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void FullWhiteSpaceDescription_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string fullWhiteSpaceDescription = "      ";

            bool actualValidity = _descriptionRule.Validate(fullWhiteSpaceDescription).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void TooLongDescription_ReturnsFailedDescriptionRuleStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.FailedDescriptionRule;
            string tooLongDescription = new('x', DescriptionRule._maxDescriptionLength + 1);

            ValidationStatus actualStatus = _descriptionRule.Validate(tooLongDescription).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void TooLongDescription_ReturnsInvalidResult()
        {
            bool expectedValidity = false;
            string tooLongDescription = new ('x', DescriptionRule._maxDescriptionLength + 1);

            bool actualValidity = _descriptionRule.Validate(tooLongDescription).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }

        [Fact]
        public void ValidDescription_ReturnsOkStatus()
        {
            ValidationStatus expectedStatus = ValidationStatus.Ok;
            string validDescription = "x";

            ValidationStatus actualStatus = _descriptionRule.Validate(validDescription).Status;

            Assert.Equal(actualStatus, expectedStatus);
        }

        [Fact]
        public void ValidDescription_ReturnsValidResult()
        {
            bool expectedValidity = true;
            string validDescription = "x";

            bool actualValidity = _descriptionRule.Validate(validDescription).IsValid;

            Assert.Equal(actualValidity, expectedValidity);
        }
    }
}
